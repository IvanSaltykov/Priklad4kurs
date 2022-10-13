using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lrs.Controllers
{
    [Route("api/partworlds/{partWorldId}/countries/{countryId}/cities/{cityId}/hotels/{hotelId}/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public TicketsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTickets(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId)
        { 
            var actionResult = checkResult(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticketsFromDb = _repository.Ticket.GetTickets(hotelId, false);
            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(ticketsFromDb);
            return Ok(ticketsDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Guid id)
        {
            var actionResult = checkResult(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticketDb = _repository.Ticket.GetTicket(hotelId, id, false);
            if (ticketDb == null)
            {
                _logger.LogInfo($"Ticket with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var ticket = _mapper.Map<TicketDto>(ticketDb);
            return Ok(ticket);
        }
        private IActionResult checkResult(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId)
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
            var hotel = _repository.Hotel.GetHotel(cityId, hotelId, false);
            if (hotel == null)
            {
                _logger.LogInfo($"Hotel with id: {hotelId} doesn't exist in the database.");
                return NotFound();
            }
            return null;
        }
    }
}
