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
        public IActionResult GetPartWorld(Guid id)
        {
            var partWorld = _repository.PartWorld.GetPartWorld(id, false);
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
        public IActionResult GetPartWorlds()
        {
            var partWorlds = _repository.PartWorld.GetAllPartWorlds(false);
            var partWorldsDto = _mapper.Map<IEnumerable<PartWorldDto>>(partWorlds);
            return Ok(partWorldsDto);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePartWorld(Guid id)
        {
            var partWorld = _repository.PartWorld.GetPartWorld(id, false);
            if (partWorld == null)
            {
                _logger.LogInfo($"PartWorld with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.PartWorld.DeletePartWorld(partWorld);
            _repository.Save();
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreatePartWorld([FromBody] PartWorldCreateDto partWorld)
        {
            if (partWorld == null)
            {
                _logger.LogError("PartWorldCreateDto object sent from client is null.");
                return BadRequest("PartWorldCreateDto object is null");
            }
            var partWorldEntity = _mapper.Map<PartWorld>(partWorld);
            _repository.PartWorld.CreatePartWorld(partWorldEntity);
            _repository.Save();
            var partWorldReturn = _mapper.Map<PartWorldDto>(partWorldEntity);
            return CreatedAtRoute("GetPartWorld", new
            {
                partWorldReturn.Id
            }, partWorldReturn);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePartWorld(Guid id, [FromBody] PartWorldUpdateDto partWorld)
        {
            if (partWorld == null)
            {
                _logger.LogError("PartWorldCreateDto object sent from client is null.");
                return BadRequest("PartWorldCreateDto object is null");
            }
            var partWorldEntity = _repository.PartWorld.GetPartWorld(id, true);
            if (partWorldEntity == null)
            {
                _logger.LogInfo($"PartWorld with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(partWorld, partWorldEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
