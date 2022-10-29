using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using lrs.ActionFilters;
using lrs.ModelBinders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Data.SqlTypes;

namespace lrs.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/companies")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CompaniesController : ControllerBase
    {
        private readonly IDataShaper<CompanyDto> _dataShaper;
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CompaniesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IDataShaper<CompanyDto> dataShaper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        /// <summary>
        /// Возвращает все компании
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Компании</returns>
        /// <response code="401">Требуется авторизация пользователя</response>
        [HttpGet(Name = "GetCompanies"), Authorize(Roles = "Manager")]
        [HttpHead]
        public async Task<IActionResult> GetCompanies([FromQuery] CompanyParameters parameters)
        {
            var companies = await _repository.Company.GetAllCompaniesAsync(false, parameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(companies.MetaData));
            var companyDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(_dataShaper.ShapeData(companyDto, parameters.Fields));
        }
        /// <summary>
        /// Возвращает компанию по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "CompanyById")]
        [HttpHead("{id}")]
        public async Task<IActionResult> GetCompany(Guid id, [FromQuery] CompanyParameters parameters)
        {
            var company = await _repository.Company.GetCompanyAsync(id, false);
            if (company == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(_dataShaper.ShapeData(companyDto, parameters.Fields));
        }
        /// <summary>
        /// Создает новую компанию в базе данных
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);
            _repository.Company.CreateCompany(companyEntity);
            await _repository.SaveAsync();
            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
            return CreatedAtRoute("CompanyById", new { id = companyToReturn.Id },companyToReturn);
        }
        /// <summary>
        /// Возвращает коллекцию компаний
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            var companyEntities = await _repository.Company.GetByIdsAsync(ids, false);
            if (ids.Count() != companyEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }
            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            return Ok(companiesToReturn);
        }
        /// <summary>
        /// Создает коллекцию компаний
        /// </summary>
        /// <param name="companyCollection"></param>
        /// <returns></returns>
        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection == null)
            {
                _logger.LogError("Company collection sent from client is null.");
                return BadRequest("Company collection is null");
            }
            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _repository.Company.CreateCompany(company);
            }
            await _repository.SaveAsync();
            var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));
            return CreatedAtRoute("CompanyCollection", new { ids }, companyCollectionToReturn);
        }
        /// <summary>
        /// Удаляет компанию по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateCompanyExistsAttribute))]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var company = HttpContext.Items["company"] as Company;
            _repository.Company.DeleteCompany(company);
            await _repository.SaveAsync();
            return NoContent();
        }
        /// <summary>
        /// Изменяет компанию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateCompanyExistsAttribute))]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            var companyEntity = HttpContext.Items["company"] as Company;
            _mapper.Map(company, companyEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
        /// <summary>
        /// Возвращает заголовки запросов
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, DELETE, PUT");
            return Ok();
        }
    }
}
