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
            try
            {
                return Ok(await _timereport.GetAll());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await _timereport.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateNewEmployee(Employee newEmp)
        {
            try
            {
                if (newEmp == null)
                {
                    return BadRequest();
                }
                var createdEmp = await _timereport.Add(newEmp);
                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmp.EmployeeId, createdEmp });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var empToDelete = await _timereport.GetSingle(id);
                if (empToDelete == null)
                {
                    return NotFound($"Employee with id {id} not found");
                }
                return await _timereport.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete from database");
            }
        }

        [HttpPut{"{id}"]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee emp)
        {
            try
            {
                if (id != emp.EmployeeId)
                {
                    return BadRequest("Employee id does not match");
                }
                var empToUpdate = await _timereport.GetSingle(id);
                if (empToUpdate == null)
                {
                    return NotFound($"Employee with id {id} not found");
                }
                return await _timereport.Update(empToUpdate);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update to database");
            }
        }
         
    }
}
