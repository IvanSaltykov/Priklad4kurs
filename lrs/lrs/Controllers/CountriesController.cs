using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using lrs.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace lrs.Controllers
{
    [Route("api/partworlds/{partWorldId}/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<CountryDto> _dataShaper;

        public CountriesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IDataShaper<CountryDto> dataShaper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountriesAsync(Guid partWorldId, [FromQuery] CountryParameters parameters)
        {
            var actionResult = await checkResultAsync(partWorldId);
            if (actionResult != null)
                return actionResult;
            var countriesFromDb = await _repository.Country.GetCountriesAsync(partWorldId, parameters, false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(countriesFromDb.MetaData));
            var countriesDto = _mapper.Map<IEnumerable<CountryDto>>(countriesFromDb);
            return Ok(_dataShaper.ShapeData(countriesDto, parameters.Fields));
        }
        [HttpGet("{id}", Name = "GetCountry")]
        public async Task<IActionResult> GetCountryAsync(Guid partWorldId, Guid id, [FromQuery] CountryParameters parameters)
        {
            var actionResult = await checkResultAsync(partWorldId);
            if (actionResult != null)
                return actionResult;
            var countryDb = await _repository.Country.GetCountryAsync(partWorldId, id, false);
            if (countryDb == null)
            {
                _logger.LogInfo($"Country with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var countryDto = _mapper.Map<CountryDto>(countryDb);
            return Ok(_dataShaper.ShapeData(countryDto, parameters.Fields));
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCountryAsync(Guid partWorldId, [FromBody] CountryCreateDto country)
        {
            var actionResult = await checkResultAsync(partWorldId);
            if (actionResult != null)
                return actionResult;
            var countryEntity = _mapper.Map<Country>(country);
            _repository.Country.CreateCountry(partWorldId, countryEntity);
            await _repository.SaveAsync();
            var countryReturn = _mapper.Map<CountryDto>(countryEntity);
            return CreatedAtRoute("GetCountry", new { 
                partWorldId,
                countryReturn.Id
            }, countryReturn);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryAsync(Guid partWorldId, Guid id)
        {
            var actionResult = await checkResultAsync(partWorldId);
            if (actionResult != null)
                return actionResult;
            var country = await _repository.Country.GetCountryAsync(partWorldId, id, false);
            if (country == null)
            {
                _logger.LogInfo($"Ccountry with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Country.DeleteCountry(country);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateCountryExistsAttribute))]
        public async Task<IActionResult> UpdateCountryAsync(Guid partWorldId, Guid id, [FromBody] CountryUpdateDto country)
        {
            var countryEntity = HttpContext.Items["country"] as Country;
            _mapper.Map(country, countryEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
        private async Task<IActionResult> checkResultAsync(Guid partWorldId)
        {
            var partWorld = await _repository.PartWorld.GetPartWorldAsync(partWorldId, false);
            if (partWorld == null)
            {
                _logger.LogInfo($"Partworld with id: {partWorldId} doesn't exist in the database.");
                return NotFound();
            }
            return null;
        }
    }
}
