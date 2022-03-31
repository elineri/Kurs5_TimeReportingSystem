using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeReportingSystem.API.Model;
using TimeReportingSystem.Models;

namespace TimeReportingSystem.API.Services
{
    public class EmployeeRepo : ITimeReport<Employee>
    {
        private TimeReportDbContext _timeReportContext;
        public EmployeeRepo(TimeReportDbContext timeReportContext)
        {
            _timeReportContext = timeReportContext;
        }
        public async Task<Employee> Add(Employee newEntity)
        {
            var result = await _timeReportContext.Employees.AddAsync(newEntity);
            await _timeReportContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Delete(int id)
        {
            var toDelete = await _timeReportContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (toDelete != null)
            {
                var result = _timeReportContext.Employees.Remove(toDelete);
                await _timeReportContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _timeReportContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetSingle(int id)
        {
            return await _timeReportContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<Employee> PersonReportedTime(int id)
        {
            return await _timeReportContext.Employees.Include(t => t.TimeReports).FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<Employee> Update(Employee Entity)
        {
            var toUpdate = await _timeReportContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == Entity.EmployeeId);
            if (toUpdate != null)
            {
                toUpdate.FirstName = Entity.FirstName;
                toUpdate.LastName = Entity.LastName;
                toUpdate.PhoneNumber = Entity.PhoneNumber;
                toUpdate.Email = Entity.Email;
                toUpdate.Role = Entity.Role;
                toUpdate.StartDate = Entity.StartDate;
                toUpdate.EndDate = Entity.EndDate;

                await _timeReportContext.SaveChangesAsync();
                return toUpdate;
            }
            return null;
        }
    }
}
