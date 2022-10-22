using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
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

        public PartWorldsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("{id}", Name = "GetPartWorld")]
        public async Task<IActionResult> GetPartWorldAsync(Guid id)
        {
            var partWorld = await _repository.PartWorld.GetPartWorldAsync(id, false);
            if (partWorld == null)
            {
                _logger.LogInfo($"PartWorld with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var partWorldDto = _mapper.Map<PartWorldDto>(partWorld);
                return Ok(partWorldDto);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPartWorldsAsync()
        {
            var partWorlds = await _repository.PartWorld.GetAllPartWorldsAsync(false);
            var partWorldsDto = _mapper.Map<IEnumerable<PartWorldDto>>(partWorlds);
            return Ok(partWorldsDto);
        }
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
            _repository.SaveAsync();
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePartWorldAsync([FromBody] PartWorldCreateDto partWorld)
        {
            if (partWorld == null)
            {
                _logger.LogError("PartWorldCreateDto object sent from client is null.");
                return BadRequest("PartWorldCreateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the PartWorldCreateDto object");
                return UnprocessableEntity(ModelState);
            }
            var partWorldEntity = _mapper.Map<PartWorld>(partWorld);
            _repository.PartWorld.CreatePartWorld(partWorldEntity);
            _repository.SaveAsync();
            var partWorldReturn = _mapper.Map<PartWorldDto>(partWorldEntity);
            return CreatedAtRoute("GetPartWorld", new
            {
                partWorldReturn.Id
            }, partWorldReturn);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartWorldAsync(Guid id, [FromBody] PartWorldUpdateDto partWorld)
        {
            if (partWorld == null)
            {
                _logger.LogError("PartWorldCreateDto object sent from client is null.");
                return BadRequest("PartWorldCreateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the PartWorldUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var partWorldEntity = await _repository.PartWorld.GetPartWorldAsync(id, true);
            if (partWorldEntity == null)
            {
                _logger.LogInfo($"PartWorld with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(partWorld, partWorldEntity);
            _repository.SaveAsync();
            return NoContent();
        }
    }
}
