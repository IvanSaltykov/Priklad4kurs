using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lrs.Controllers
{
    [Route("api/partwords")]
    [ApiController]
    public class PartWorldsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public PartWorldsController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetPartWorld()
        {
            var partWorlds = _repository.PartWorld.GetAllPartWorlds(trackChanges: false);
            var partWorldsDto = partWorlds.Select(c => new PartWorldDto
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
            return Ok(partWorldsDto);
        }
    }
}
