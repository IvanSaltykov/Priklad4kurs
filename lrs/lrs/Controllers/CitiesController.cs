using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using lrs.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace lrs.Controllers
{
    [Route("api/partworlds/{partWorldId}/countries/{countryId}/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<CityDto> _dataShaper;

        public CitiesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IDataShaper<CityDto> dataShaper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        /// <summary>
        /// Возвращает список городов страны
        /// </summary>
        /// <param name="partWorldId">Id Части света</param>
        /// <param name="countryId">Id Страны</param>
        /// <param name="parameters">Параметра возвращения массива данных</param>
        /// <returns></returns>
        [HttpGet, Authorize]
        [HttpHead]
        public async Task<IActionResult> GetCitiesAsync(Guid partWorldId, Guid countryId, [FromQuery] CityParameters parameters)
        {
            var actionResult = await checkResultAsync(partWorldId, countryId);
            if (actionResult != null)
                return actionResult;
            var citiesFromDb = await _repository.City.GetCitiesAsync(countryId, parameters, false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(citiesFromDb.MetaData));
            var citiesDto = _mapper.Map<IEnumerable<CityDto>>(citiesFromDb);
            return Ok(_dataShaper.ShapeData(citiesDto, parameters.Fields));
        }
        /// <summary>
        /// Возвращает город страны id
        /// </summary>
        /// <param name="partWorldId">Id Части света</param>
        /// <param name="countryId">Id Страны</param>
        /// <param name="id">Id города</param>
        /// <param name="parameters">Параметра возвращения массива данных</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetCity"), Authorize]
        [HttpHead("{id}")]
        public async Task<IActionResult> GetCityAsync(Guid partWorldId, Guid countryId, Guid id, [FromQuery] CityParameters parameters)
        {
            var actionResult = await checkResultAsync(partWorldId, countryId);
            if (actionResult != null)
                return actionResult;
            var cityDb = await _repository.City.GetCityAsync(countryId, id, false);
            if (cityDb == null)
            {
                _logger.LogInfo($"City with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var cityDto = _mapper.Map<CityDto>(cityDb);
            return Ok(_dataShaper.ShapeData(cityDto, parameters.Fields));
        }
        /// <summary>
        /// Создает город
        /// </summary>
        /// <param name="partWorldId">Id Части света</param>
        /// <param name="countryId">Id Страны</param>
        /// <param name="city">Название города</param>
        /// <returns></returns>
        [HttpPost, Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCityAsync(Guid partWorldId, Guid countryId, [FromBody] CityCreateDto city)
        {
            var actionResult = await checkResultAsync(partWorldId, countryId);
            if (actionResult != null)
                return actionResult;
            var cityEntity = _mapper.Map<City>(city);
            _repository.City.CreateCity(countryId, cityEntity);
            await _repository.SaveAsync();
            var cityReturn = _mapper.Map<CityDto>(cityEntity);
            return CreatedAtRoute("GetCity", new
            {
                partWorldId,
                countryId,
                cityReturn.Id
            }, cityReturn);
        }
        /// <summary>
        /// Удалает город
        /// </summary>
        /// <param name="partWorldId">Id Части света</param>
        /// <param name="countryId">Id Страны</param>
        /// <param name="id">Id города</param>
        /// <returns></returns>
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteCityAsync(Guid partWorldId, Guid countryId, Guid id)
        {
            var actionResult = await checkResultAsync(partWorldId, countryId);
            if (actionResult != null)
                return actionResult;
            var city = await _repository.City.GetCityAsync(countryId, id, false);
            if (city == null)
            {
                _logger.LogInfo($"City with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.City.DeleteCity(city);
            await _repository.SaveAsync();
            return NoContent();
        }
        /// <summary>
        /// Обновляет город
        /// </summary>
        /// <param name="partWorldId">Id Части света</param>
        /// <param name="countryId">Id Страны</param>
        /// <param name="id">Id города</param>
        /// <param name="city">Новое название города</param>
        /// <returns></returns>
        [HttpPut("{id}"), Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateCityExistsAttribute))]
        public async Task<IActionResult> UpdateCityAsync(Guid partWorldId, Guid countryId, Guid id, [FromBody] CityUpdateDto city)
        {
            var cityEntity = HttpContext.Items["city"] as City;
            _mapper.Map(city, cityEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
        private async Task<IActionResult> checkResultAsync(Guid partWorldId, Guid countryId)
        {
            var partWorld = await _repository.PartWorld.GetPartWorldAsync(partWorldId, false);
            if (partWorld == null)
            {
                _logger.LogInfo($"Partworld with id: {partWorldId} doesn't exist in the database.");
                return NotFound();
            }
            var country = await _repository.Country.GetCountryAsync(partWorldId, countryId, false);
            if (country == null)
            {
                _logger.LogInfo($"Country with id: {countryId} doesn't exist in the database.");
                return NotFound();
            }
            return null;
        }
        /// <summary>
        /// Возвращает заголовки запросов
        /// </summary>
        /// <returns></returns>
        [HttpOptions, Authorize]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, DELETE, PUT, PATCH");
            return Ok();
        }
    }
}
