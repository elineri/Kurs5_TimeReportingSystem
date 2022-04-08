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
    public class ProjectsController : ControllerBase
    {
        private readonly ITimeReport<Project> _projects;

        public ProjectsController(ITimeReport<Project> projects)
        {
            _projects = projects;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProjects()
        {
            try
            {
                return Ok(await _projects.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        } 

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            try
            {
                var result = await _projects.GetSingle(id);
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
        public async Task<ActionResult<Project>> CreateNewProject(Project newProj)
        {
            try
            {
                if (newProj == null)
                {
                    return BadRequest();
                }
                var createdProj = await _projects.Add(newProj);
                return CreatedAtAction(nameof(GetProject), new { id = createdProj.ProjectId }, createdProj );
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add data to database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            try
            {
                var projToDelete = await _projects.Delete(id);
                if (projToDelete == null)
                {
                    return NotFound($"Project with id {id} not found");
                }
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete from database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project proj)
        {
            try
            {
                if (id != proj.ProjectId)
                {
                    return BadRequest("Product id doesn't match");
                }
                var projToUpdate = await _projects.GetSingle(id);
                if (projToUpdate == null)
                {
                    return NotFound($"Project with id {id} not found");
                }
                return await _projects.Update(proj);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update database");
            }
        }

        [HttpGet("{id}/employees")]
        public async Task<ActionResult<Project>> GetProjectEmployees(int id)
        {
            try
            {
                return Ok(await _projects.ProjectEmployees(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }
    }
}
