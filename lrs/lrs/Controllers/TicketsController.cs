using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lrs.Controllers
{
    [Route("api/tickets")]
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
        public IActionResult GetTicket()
        {
            var tickets = _repository.Ticket.GetAllTickets(false);
            //var ticketsDto = tickets.Select(c => new TicketDto
            //{
            //    Id = c.Id,
            //    World = c.World,
            //    Country = c.Country,
            //    City = c.City,
            //    Hotel = c.Hotel,
            //    User = c.User,
            //    Week = c.Week,
            //    Price = c.Price
            //}).ToList();
            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(tickets);
            return Ok(ticketsDto);
        }
    }
}
