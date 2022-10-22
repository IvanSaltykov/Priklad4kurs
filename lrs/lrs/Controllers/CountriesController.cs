using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public CountriesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountriesAsync(Guid partWorldId)
        {
            var actionResult = await checkResultAsync(partWorldId);
            if (actionResult != null)
                return actionResult;
            var countriesFromDb = await _repository.Country.GetCountriesAsync(partWorldId, false);
            var countriesDto = _mapper.Map<IEnumerable<CountryDto>>(countriesFromDb);
            return Ok(countriesDto);
        }
        [HttpGet("{id}", Name = "GetCountry")]
        public async Task<IActionResult> GetCountryAsync(Guid partWorldId, Guid id)
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
            var country = _mapper.Map<CountryDto>(countryDb);
            return Ok(country);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCountryAsync(Guid partWorldId, [FromBody] CountryCreateDto country)
        {
            if (country == null)
            {
                _logger.LogError("CountryCreateDto object sent from client is null.");
                return BadRequest("CountryCreateDto object is null"); ;
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CountryCreateDto object");
                return UnprocessableEntity(ModelState);
            }
            var actionResult = await checkResultAsync(partWorldId);
            if (actionResult != null)
                return actionResult;
            var countryEntity = _mapper.Map<Country>(country);
            _repository.Country.CreateCountry(partWorldId, countryEntity);
            _repository.SaveAsync();
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
            _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountryAsync(Guid partWorldId, Guid id, [FromBody] CountryUpdateDto country)
        {
            if (country == null)
            {
                _logger.LogError("CountryUpdateDto object sent from client is null.");
                return BadRequest("CountryUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CountryUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var actionResult = await checkResultAsync(partWorldId);
            if (actionResult != null)
                return actionResult;
            var countryEntity = await _repository.Country.GetCountryAsync(partWorldId, id, true);
            if (countryEntity == null)
            {
                _logger.LogInfo($"Country with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(country, countryEntity);
            _repository.SaveAsync();
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
