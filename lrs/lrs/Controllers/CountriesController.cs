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
        public IActionResult GetCountries(Guid partWorldId)
        {
            var actionResult = checkResult(partWorldId);
            if (actionResult != null)
                return actionResult;
            var countriesFromDb = _repository.Country.GetCountries(partWorldId, false);
            var countriesDto = _mapper.Map<IEnumerable<CountryDto>>(countriesFromDb);
            return Ok(countriesDto);
        }
        [HttpGet("{id}", Name = "GetCountry")]
        public IActionResult GetCountry(Guid partWorldId, Guid id)
        {
            var actionResult = checkResult(partWorldId);
            if (actionResult != null)
                return actionResult;
            var countryDb = _repository.Country.GetCountry(partWorldId, id, false);
            if (countryDb == null)
            {
                _logger.LogInfo($"Country with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var country = _mapper.Map<CountryDto>(countryDb);
            return Ok(country);
        }
        [HttpPost]
        public IActionResult CreateCountry(Guid partWorldId, [FromBody] CountryCreateDto country)
        {
            if (country == null)
            {
                _logger.LogError("CountryCreateDto object sent from client is null.");
                return BadRequest("CountryCreateDto object is null"); ;
            }
            var actionResult = checkResult(partWorldId);
            if (actionResult != null)
                return actionResult;
            var countryEntity = _mapper.Map<Country>(country);
            _repository.Country.CreateCountry(partWorldId, countryEntity);
            _repository.Save();
            var countryReturn = _mapper.Map<CountryDto>(countryEntity);
            return CreatedAtRoute("GetCountry", new { 
                partWorldId,
                countryReturn.Id
            }, countryReturn);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(Guid partWorldId, Guid id)
        {
            var actionResult = checkResult(partWorldId);
            if (actionResult != null)
                return actionResult;
            var country = _repository.Country.GetCountry(partWorldId, id, false);
            if (country == null)
            {
                _logger.LogInfo($"Ccountry with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Country.DeleteCountry(country);
            _repository.Save();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCountry(Guid partWorldId, Guid id, [FromBody] CountryUpdateDto country)
        {
            if (country == null)
            {
                _logger.LogError("CountryUpdateDto object sent from client is null.");
                return BadRequest("CountryUpdateDto object is null");
            }
            var actionResult = checkResult(partWorldId);
            if (actionResult != null)
                return actionResult;
            var countryEntity = _repository.Country.GetCountry(partWorldId, id, true);
            if (countryEntity == null)
            {
                _logger.LogInfo($"Country with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(country, countryEntity);
            _repository.Save();
            return NoContent();
        }
        private IActionResult checkResult(Guid partWorldId)
        {
            var partWorld = _repository.PartWorld.GetPartWorld(partWorldId, false);
            if (partWorld == null)
            {
                _logger.LogInfo($"Partworld with id: {partWorldId} doesn't exist in the database.");
                return NotFound();
            }
            return null;
        }
    }
}
