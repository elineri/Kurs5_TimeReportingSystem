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
        private TimeReportDbContext _timeDbContext;
        public EmployeeRepo(TimeReportDbContext timeDbContext)
        {
            _timeDbContext = timeDbContext;
        }
        public async Task<Employee> Add(Employee newEntity)
        {
            var result = await _timeDbContext.Employees.AddAsync(newEntity);
            await _timeDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Delete(int id)
        {
            var result = await _timeDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (result != null)
            {
                _timeDbContext.Employees.Remove(result);
                await _timeDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _timeDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetSingle(int id)
        {
            return await _timeDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<Employee> Update(Employee Entity)
        {
            var result = await _timeDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == Entity.EmployeeId);
            if (result != null)
            {
                result.FirstName = Entity.FirstName;
                result.LastName = Entity.LastName;
                result.PhoneNumber = Entity.PhoneNumber;
                result.Email = Entity.Email;
                result.Role = Entity.Role;
                result.StartDate = Entity.StartDate;
                result.EndDate = Entity.EndDate;

                await _timeDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
