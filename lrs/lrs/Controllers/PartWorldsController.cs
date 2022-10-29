using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using lrs.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lrs.Controllers
{
    [Route("api/partworlds")]
    [ApiController]
    public class PartWorldsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<PartWorldDto> _dataShaper;

        public PartWorldsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IDataShaper<PartWorldDto> dataShaper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        /// <summary>
        /// Возвращает часть света по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetPartWorld")]
        [HttpHead("{id}")]
        public async Task<IActionResult> GetPartWorldAsync(Guid id, [FromQuery] PartWorldParameters parameters)
        {
            var partWorld = await _repository.PartWorld.GetPartWorldAsync(id, false);
            if (partWorld == null)
            {
                _logger.LogInfo($"PartWorld with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var partWorldDto = _mapper.Map<PartWorldDto>(partWorld);
            return Ok(_dataShaper.ShapeData(partWorldDto, parameters.Fields));
        }
        /// <summary>
        /// Возвращает список частей света
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpHead]
        [HttpGet]
        public async Task<IActionResult> GetPartWorldsAsync([FromQuery] PartWorldParameters parameters)
        {
            var partWorlds = await _repository.PartWorld.GetAllPartWorldsAsync(false, parameters);
            var partWorldsDto = _mapper.Map<IEnumerable<PartWorldDto>>(partWorlds);
            return Ok(_dataShaper.ShapeData(partWorldsDto, parameters.Fields));
        }
        /// <summary>
        /// Удаляет часть света
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartWorldAsync(Guid id)
        {
            var partWorld = await _repository.PartWorld.GetPartWorldAsync(id, false);
            if (partWorld == null)
            {
                _logger.LogInfo($"PartWorld with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.PartWorld.DeletePartWorld(partWorld);
            await _repository.SaveAsync();
            return NoContent();
        }
        /// <summary>
        /// Создает часть света
        /// </summary>
        /// <param name="partWorld"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePartWorldAsync([FromBody] PartWorldCreateDto partWorld)
        {
            var partWorldEntity = _mapper.Map<PartWorld>(partWorld);
            _repository.PartWorld.CreatePartWorld(partWorldEntity);
            await _repository.SaveAsync();
            var partWorldReturn = _mapper.Map<PartWorldDto>(partWorldEntity);
            return CreatedAtRoute("GetPartWorld", new
            {
                partWorldReturn.Id
            }, partWorldReturn);
        }
        /// <summary>
        /// Обновляет часть света
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partWorld"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidatePartWorldExistsAttribute))]
        public async Task<IActionResult> UpdatePartWorldAsync(Guid id, [FromBody] PartWorldUpdateDto partWorld)
        {
            var partWorldEntity = HttpContext.Items["partWorld"] as PartWorld;
            _mapper.Map(partWorld, partWorldEntity);
            _repository.SaveAsync();
            return NoContent();
        }
        /// <summary>
        /// Возвращает заголовки запросов
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, DELETE, PUT, PATCH");
            return Ok();
        }
    }
}
