using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeReportingSystem.API.Model;
using TimeReportingSystem.Models;

namespace TimeReportingSystem.API.Services
{
    public class ProjectRepo: ITimeReport<Project>
    {
        private TimeReportDbContext _timeReportContext;

        public ProjectRepo(TimeReportDbContext timeReportContext)
        {
            _timeReportContext = timeReportContext;
        }

        public async Task<Project> Add(Project newEntity)
        {
            var result = await _timeReportContext.Projects.AddAsync(newEntity);
            await _timeReportContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Project> Delete(int id)
        {
            var toDelete = await _timeReportContext.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (toDelete != null)
            {
                var result = _timeReportContext.Projects.Remove(toDelete);
                await _timeReportContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _timeReportContext.Projects.ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {
            return await _timeReportContext.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        public Task<Project> PersonReportedTime(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> Update(Project Entity)
        {
            var toUpdate = await _timeReportContext.Projects.FirstOrDefaultAsync(p => p.ProjectId == Entity.ProjectId);
            if (toUpdate != null)
            {
                toUpdate.ProjectName = Entity.ProjectName;

                await _timeReportContext.SaveChangesAsync();
                return toUpdate;
            }
            return null;
        }
    }
}
