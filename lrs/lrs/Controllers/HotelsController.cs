using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lrs.Controllers
{
    [Route("api/partworlds/{partWorldId}/countries/{countryId}/cities/{cityId}/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public HotelsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetHotels(Guid partWorldId, Guid countryId, Guid cityId)
        {
            var actionResult = checkResult(partWorldId, countryId, cityId);
            if (actionResult != null)
                return actionResult;
            var hotelsFromDb = _repository.Hotel.GetHotels(cityId, false);
            var hotelsDto = _mapper.Map<IEnumerable<HotelDto>>(hotelsFromDb);
            return Ok(hotelsDto);
        }
        [HttpGet("{id}", Name = "GetHotel")]
        public IActionResult GetHotel(Guid partWorldId, Guid countryId, Guid cityId, Guid id)
        {
            var actionResult = checkResult(partWorldId, countryId, cityId);
            if (actionResult != null)
                return actionResult;
            var hotelDb = _repository.Hotel.GetHotel(cityId, id, false);
            if (hotelDb == null)
            {
                _logger.LogInfo($"Hotel with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var hotel = _mapper.Map<HotelDto>(hotelDb);
            return Ok(hotel);
        }
        [HttpPost]
        public IActionResult GetHotel(Guid partWorldId, Guid countryId, Guid cityId, [FromBody] HotelCreateDto hotel)
        {
            if (hotel == null)
            {
                _logger.LogError("HotelCreateDto object sent from client is null.");
                return BadRequest("HotelCreateDto object is null");
            }
            var actionResult = checkResult(partWorldId, countryId, cityId);
            if (actionResult != null)
                return actionResult;
            var hotelEntity = _mapper.Map<Hotel>(hotel);
            _repository.Hotel.CreateHotel(cityId, hotelEntity);
            _repository.Save();
            var hotelReturn = _mapper.Map<HotelDto>(hotelEntity);
            return CreatedAtRoute("GetHotel", new
            {
                partWorldId,
                countryId,
                cityId,
                hotelReturn.Id
            }, hotelReturn);
        }
        private IActionResult checkResult(Guid partWorldId, Guid countryId, Guid cityId)
        {
            var partWorld = _repository.PartWorld.GetPartWorld(partWorldId, false);
            if (partWorld == null)
            {
                _logger.LogInfo($"Partworld with id: {partWorldId} doesn't exist in the database.");
                return NotFound();
            }
            var country = _repository.Country.GetCountry(partWorldId, countryId, false);
            if (country == null)
            {
                _logger.LogInfo($"Country with id: {countryId} doesn't exist in the database.");
                return NotFound();
            }
            var city = _repository.City.GetCity(countryId, cityId, false);
            if (city == null)
            {
                _logger.LogInfo($"City with id: {countryId} doesn't exist in the database.");
                return NotFound();
            }
            return null;
        }
    }
}
