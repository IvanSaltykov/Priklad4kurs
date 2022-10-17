using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name = "GetTicket")]
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
        [HttpPost]
        public IActionResult CreateTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, [FromBody] TicketCreateDto ticket)
        {
            if (ticket == null)
            {
                _logger.LogError("TicketCreationDto object sent from client is null.");
                return BadRequest("TicketCreationDto object is null");
            }
            var actionResult = checkResult(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticketEntity = _mapper.Map<Ticket>(ticket);
            _repository.Ticket.CreateTicket(partWorldId, countryId, cityId, hotelId, ticketEntity);
            _repository.Save();
            var ticketReturn = _mapper.Map<TicketDto>(ticketEntity);
            return CreatedAtRoute("GetTicket", new
            {
                partWorldId,
                countryId,
                cityId,
                hotelId,
                ticketReturn.Id
            }, ticketReturn);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Guid id, [FromBody] TicketUpdateDto ticket)
        {
            if (ticket == null)
            {
                _logger.LogError("TicketCreationDto object sent from client is null.");
                return BadRequest("TicketCreationDto object is null");
            }
            var actionResult = checkResult(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticketEntity = _repository.Ticket.GetTicket(hotelId, id, true);
            if (ticketEntity == null)
            {
                _logger.LogInfo($"Ticket with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(ticket, ticketEntity);
            _repository.Save();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Guid id)
        {
            var actionResult = checkResult(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticket = _repository.Ticket.GetTicket(hotelId, id, false);
            if (ticket == null)
            {
                _logger.LogInfo($"Ticket with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Ticket.DeleteTicket(ticket);
            _repository.Save();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult PatchUpdateTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Guid id, [FromBody] JsonPatchDocument<TicketUpdateDto> ticket)
        {
            if (ticket == null)
            {
                _logger.LogError("TicketUpdateDto object sent from client is null.");
                return BadRequest("TicketUpdateDto object is null");
            }
            var actionResult = checkResult(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticketEntity = _repository.Ticket.GetTicket(hotelId, id, true);
            if (ticketEntity == null)
            {
                _logger.LogInfo($"Ticket with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var ticketToPatch = _mapper.Map<TicketUpdateDto>(ticketEntity);
            ticket.ApplyTo(ticketToPatch);
            _mapper.Map(ticketToPatch, ticketEntity);
            _repository.Save();
            return NoContent();
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
