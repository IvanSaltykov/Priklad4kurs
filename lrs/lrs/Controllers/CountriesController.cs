using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [HttpGet("{id}")]
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
