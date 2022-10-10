using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lrs.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CountriesController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _repository.Country.GetAllCountries(false);
            var countriesDto = countries.Select(c => new CountryDto
            {
                Id = c.Id,
                Name = c.Name,
                PartWorldId = c.PartWorldId
            }).ToList();
            return Ok(countriesDto);
        }
    }
}
