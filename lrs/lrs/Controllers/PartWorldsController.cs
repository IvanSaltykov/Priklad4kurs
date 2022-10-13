using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
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
        [HttpGet("{id}")]
        public IActionResult GetPartWorld(Guid id)
        {
            var partWorlds = _repository.PartWorld.GetPartWorld(id, false);
            if (partWorlds == null)
            {
                _logger.LogInfo($"PartWorld with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var partWorldsDto = _mapper.Map<PartWorldDto>(partWorlds);
                return Ok(partWorldsDto);
            }
        }
        [HttpGet]
        public IActionResult GetPartWorlds()
        {
            var partWorlds = _repository.PartWorld.GetAllPartWorlds(false);
            var partWorldsDto = _mapper.Map<IEnumerable<PartWorldDto>>(partWorlds);
            return Ok(partWorldsDto);
        }
    }
}
