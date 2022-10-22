using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lrs.Controllers
{
    [Route("api/partworlds/{partWorldId}/countries/{countryId}/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CitiesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCitiesAsync(Guid partWorldId, Guid countryId)
        {
            var actionResult = await checkResultAsync(partWorldId, countryId);
            if (actionResult != null)
                return actionResult;
            var citiesFromDb = await _repository.City.GetCitiesAsync(countryId, false);
            var citiesDto = _mapper.Map<IEnumerable<CityDto>>(citiesFromDb);
            return Ok(citiesDto);
        }
        [HttpGet("{id}", Name = "GetCity")]
        public async Task<IActionResult> GetCityAsync(Guid partWorldId, Guid countryId, Guid id)
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
            var city = _mapper.Map<CityDto>(cityDb);
            return Ok(city);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCityAsync(Guid partWorldId, Guid countryId, [FromBody] CityCreateDto city)
        {
            if (city == null)
            {
                _logger.LogError("CityCreateDto object sent from client is null.");
                return BadRequest("CityCreateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CityCreateDto object");
                return UnprocessableEntity(ModelState);
            }
            var actionResult = await checkResultAsync(partWorldId, countryId);
            if (actionResult != null)
                return actionResult;
            var cityEntity = _mapper.Map<City>(city);
            _repository.City.CreateCity(countryId, cityEntity);
            _repository.SaveAsync();
            var cityReturn = _mapper.Map<CityDto>(cityEntity);
            return CreatedAtRoute("GetCity", new
            {
                partWorldId,
                countryId,
                cityReturn.Id
            }, cityReturn);
        }
        [HttpDelete("{id}")]
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
            _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCityAsync(Guid partWorldId, Guid countryId, Guid id, [FromBody] CityUpdateDto city)
        {
            if (city == null)
            {
                _logger.LogError("CityUpdateDto object sent from client is null.");
                return BadRequest("CityUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CityUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var actionResult = await checkResultAsync(partWorldId, countryId);
            if (actionResult != null)
                return actionResult;
            var cityEntity = await _repository.City.GetCityAsync(countryId, id, true);
            if (cityEntity == null)
            {
                _logger.LogInfo($"City with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(city, cityEntity);
            _repository.SaveAsync();
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
    }
}
