using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lrs.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public HotelsController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetHotels ()
        {
            var hotels = _repository.Hotel.GetAllHotels(false);
            var hotelsDto = hotels.Select(c => new HotelDto
            {
                Id = c.Id,
                Name = c.Name,
                CityId = c.CityId,
            }).ToList();
            return Ok(hotelsDto);
        }
    }
}
