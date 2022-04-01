﻿using Microsoft.AspNetCore.Http;
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
    public class TimeReportsController : ControllerBase
    {
        private ITimeReport<TimeReport> _timeReports;
        public TimeReportsController(ITimeReport<TimeReport> timeReports)
        {
            _timeReports = timeReports;
        }

        [HttpGet]
        public async Task<ActionResult<TimeReport>> GetAllTimeReports()
        {
            try
            {
                return Ok(await _timeReports.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TimeReport>> GetTimeReport(int id)
        {
            try
            {
                var result = await _timeReports.GetSingle(id);
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
        public async Task<ActionResult<TimeReport>> CreateTimeReport(TimeReport newTime)
        {
            try
            {
                if (newTime == null)
                {
                    return BadRequest();
                }
                var createdTime = await _timeReports.Add(newTime);
                return CreatedAtAction(nameof(GetTimeReport), new { id = createdTime.TimeReportId, createdTime });
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add data to database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeReport>> DeleteTimeReport(int id)
        {
            try
            {
                var timeToDelete = await _timeReports.Delete(id);
                if (timeToDelete == null)
                {
                    return NotFound($"Time report with id {id} not found");
                }
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete from database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimeReport>> UpdateTimeReport(int id, TimeReport time)
        {
            try
            {
                if (id != time.TimeReportId)
                {
                    return BadRequest("Time report id does not match");
                }
                var timeToUpdate = await _timeReports.GetSingle(id);
                if (timeToUpdate == null)
                {
                    return NotFound($"Time report with id {id} not found");
                }
                return await _timeReports.Update(timeToUpdate);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update to database");
            }
        }
    }
}