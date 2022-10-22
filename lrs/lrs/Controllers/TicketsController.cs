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
        public async Task<IActionResult> GetTicketsAsync(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId)
        { 
            var actionResult = await checkResultAsync(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticketsFromDb = await _repository.Ticket.GetTicketsAsync(hotelId, false);
            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(ticketsFromDb);
            return Ok(ticketsDto);
        }
        [HttpGet("{id}", Name = "GetTicket")]
        public async Task<IActionResult> GetTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Guid id)
        {
            var actionResult = await checkResultAsync(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticketDb = await _repository.Ticket.GetTicketAsync(hotelId, id, false);
            if (ticketDb == null)
            {
                _logger.LogInfo($"Ticket with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var ticket = _mapper.Map<TicketDto>(ticketDb);
            return Ok(ticket);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, [FromBody] TicketCreateDto ticket)
        {
            if (ticket == null)
            {
                _logger.LogError("TicketCreationDto object sent from client is null.");
                return BadRequest("TicketCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the TicketCreateDto object");
                return UnprocessableEntity(ModelState);
            }
            var actionResult = await checkResultAsync(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticketEntity = _mapper.Map<Ticket>(ticket);
            _repository.Ticket.CreateTicket(partWorldId, countryId, cityId, hotelId, ticketEntity);
            _repository.SaveAsync();
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
        public async Task<IActionResult> UpdateTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Guid id, [FromBody] TicketUpdateDto ticket)
        {
            if (ticket == null)
            {
                _logger.LogError("TicketCreationDto object sent from client is null.");
                return BadRequest("TicketCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the TicketUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var actionResult = await checkResultAsync(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticketEntity = await _repository.Ticket.GetTicketAsync(hotelId, id, true);
            if (ticketEntity == null)
            {
                _logger.LogInfo($"Ticket with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(ticket, ticketEntity);
            _repository.SaveAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Guid id)
        {
            var actionResult = await checkResultAsync(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticket = await _repository.Ticket.GetTicketAsync(hotelId, id, false);
            if (ticket == null)
            {
                _logger.LogInfo($"Ticket with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Ticket.DeleteTicket(ticket);
            _repository.SaveAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUpdateTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Guid id, [FromBody] JsonPatchDocument<TicketUpdateDto> ticket)
        {
            if (ticket == null)
            {
                _logger.LogError("TicketUpdateDto object sent from client is null.");
                return BadRequest("TicketUpdateDto object is null");
            }
            var actionResult = await checkResultAsync(partWorldId, countryId, cityId, hotelId);
            if (actionResult != null)
                return actionResult;
            var ticketEntity = await _repository.Ticket.GetTicketAsync(hotelId, id, true);
            if (ticketEntity == null)
            {
                _logger.LogInfo($"Ticket with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var ticketToPatch = _mapper.Map<TicketUpdateDto>(ticketEntity);
            ticket.ApplyTo(ticketToPatch);
            _mapper.Map(ticketToPatch, ticketEntity);
            _repository.SaveAsync();
            return NoContent();
        }
        private async Task<IActionResult> checkResultAsync(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId)
        {
            var partWorld = await _repository.PartWorld.GetPartWorldAsync(partWorldId, false);
            if (partWorld == null)
            {
                _logger.LogInfo($"Partworld with id: {partWorldId} doesn't exist in the database.");
                return NotFound();
            }
            var country = await _repository.Country.GetCountryAsync(partWorldId, countryId, false);
            if (country == null)
            {
                _logger.LogInfo($"Country with id: {countryId} doesn't exist in the database.");
                return NotFound();
            }
            var city = await _repository.City.GetCityAsync(countryId, cityId, false);
            if (city == null)
            {
                _logger.LogInfo($"City with id: {countryId} doesn't exist in the database.");
                return NotFound();
            }
            var hotel = await _repository.Hotel.GetHotelAsync(cityId, hotelId, false);
            if (hotel == null)
            {
                _logger.LogInfo($"Hotel with id: {hotelId} doesn't exist in the database.");
                return NotFound();
            }
            return null;
        }
    }
}
