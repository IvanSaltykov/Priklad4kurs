using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace lrs.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public EmployeeController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _repository.Employee.GetAllEmployees(trackChanges: false);
            var employeesDto = employees.Select(c => new EmployeeDto
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Position = c.Position,
                CompanyId = c.CompanyId,
            }).ToList();
            return Ok(employeesDto);
        }
    }
}
