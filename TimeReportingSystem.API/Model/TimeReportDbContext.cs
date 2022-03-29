using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeReportingSystem.Models;

namespace TimeReportingSystem.API.Model
{
    public class TimeReportDbContext : DbContext
    {
        public TimeReportDbContext(DbContextOptions<TimeReportDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }
    }
}
