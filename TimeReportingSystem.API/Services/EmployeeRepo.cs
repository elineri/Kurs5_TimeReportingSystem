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
        public Task<Employee> Add(Employee newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _timeDbContext.Employees.ToListAsync();
        }

        public Task<Employee> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Update(Employee Entity)
        {
            throw new NotImplementedException();
        }
    }
}
