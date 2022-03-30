using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeReportingSystem.API.Services;
using TimeReportingSystem.Models;

namespace TimeReportingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private ITimeReport<Employee> _timereport;

        public EmployeesController(ITimeReport<Employee> timeReport)
        {
            _timereport = timeReport;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            return Ok(await _timereport.GetAll());
        }
         
    }
}
