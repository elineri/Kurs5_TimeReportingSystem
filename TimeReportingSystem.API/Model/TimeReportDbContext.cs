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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Employee
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 1, FirstName = "Hanna", LastName = "Hannasson", PhoneNumber = "0701231234", Email = "h.hannasson@company.com", Role = "Fronend developer", StartDate = new DateTime(2019,05,13) });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 2, FirstName = "Malin", LastName = "Malinsson", PhoneNumber = "0701232345", Email = "m.malinsson@company.com", Role = "Frontend developer", StartDate = new DateTime(2020,11,01) });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 3, FirstName = "Dag", LastName = "Dagsson", PhoneNumber = "0701234567", Email = "d.dagsson@company.com", Role = "Frontend developer", StartDate = new DateTime(2021,12,01) });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 4, FirstName = "Mona", LastName = "Monasson", PhoneNumber = "0701233456", Email = "m.monasson@company.com", Role = "Backend developer", StartDate = new DateTime(2020,03,15) });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 5, FirstName = "Axel", LastName = "Axelsson", PhoneNumber = "0701235678", Email = "a.axelsson@company.com", Role = "Backend developer", StartDate = new DateTime(2018,02,11) });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 6, FirstName = "Siv", LastName = "Sivsson", PhoneNumber = "0701236789", Email = "s.sivsson@company.com", Role = "QA", StartDate = new DateTime(2020,07,20) });

            // Seed project
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 1, ProjectName = "World of Warcraft" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 2, ProjectName = "Hearthstone" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 3, ProjectName = "Overwatch 2" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 4, ProjectName = "Starcraft 4" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 5, ProjectName = "Diablo" });

            // Seed time reports
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 1, EmployeeId = 1, ProjectId = 1, Date = new DateTime(2022, 02, 28), WorkedHours = 8, Note = "Bug fixing" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 2, EmployeeId = 1, ProjectId = 1, Date = new DateTime(2022, 03, 01), WorkedHours = 7, Note = "Maintenance" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 3, EmployeeId = 1, ProjectId = 2, Date = new DateTime(2022, 03, 01), WorkedHours = 1, Note = "Additional help with bug fixing" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 4, EmployeeId = 1, ProjectId = 1, Date = new DateTime(2022, 03, 02), WorkedHours = 7, Note = "Maintenance and bug fixing" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 5, EmployeeId = 1, ProjectId = 1, Date = new DateTime(2022, 03, 03), WorkedHours = 7, Note = "Maintenance" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 6, EmployeeId = 1, ProjectId = 1, Date = new DateTime(2022, 03, 04), WorkedHours = 7, Note = "Maintenance" });

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 7, EmployeeId = 2, ProjectId = 2, Date = new DateTime(2022, 02, 28), WorkedHours = 7, Note = "Maintenance" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 8, EmployeeId = 2, ProjectId = 2, Date = new DateTime(2022, 03, 01), WorkedHours = 7, Note = "Bug fixing" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 9, EmployeeId = 2, ProjectId = 3, Date = new DateTime(2022, 03, 02), WorkedHours = 8, Note = "Development" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 10, EmployeeId = 2, ProjectId = 3, Date = new DateTime(2022, 03, 03), WorkedHours = 8, Note = "Development" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 11, EmployeeId = 2, ProjectId = 3, Date = new DateTime(2022, 03, 04), WorkedHours = 8, Note = "Development" });

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 12, EmployeeId = 3, ProjectId = 4, Date = new DateTime(2022, 02, 28), WorkedHours = 8, Note = "Development" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 13, EmployeeId = 3, ProjectId = 4, Date = new DateTime(2022, 03, 02), WorkedHours = 6, Note = "Development" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 14, EmployeeId = 3, ProjectId = 4, Date = new DateTime(2022, 03, 03), WorkedHours = 8, Note = "Development" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 15, EmployeeId = 3, ProjectId = 4, Date = new DateTime(2022, 03, 04), WorkedHours = 7, Note = "Development" });

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 16, EmployeeId = 4, ProjectId = 4, Date = new DateTime(2022, 03, 01), WorkedHours = 8, Note = "Development" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 17, EmployeeId = 4, ProjectId = 4, Date = new DateTime(2022, 03, 02), WorkedHours = 8, Note = "Development" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 18, EmployeeId = 4, ProjectId = 4, Date = new DateTime(2022, 03, 03), WorkedHours = 8, Note = "Development" });

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 19, EmployeeId = 5, ProjectId = 5, Date = new DateTime(2022, 02, 28), WorkedHours = 2, Note = "Maintenance" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 20, EmployeeId = 5, ProjectId = 5, Date = new DateTime(2022, 03, 01), WorkedHours = 2, Note = "Maintenance" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 21, EmployeeId = 5, ProjectId = 5, Date = new DateTime(2022, 03, 02), WorkedHours = 2, Note = "Maintenance" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 22, EmployeeId = 5, ProjectId = 5, Date = new DateTime(2022, 03, 03), WorkedHours = 2, Note = "Maintenance" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 23, EmployeeId = 5, ProjectId = 5, Date = new DateTime(2022, 03, 04), WorkedHours = 2, Note = "Maintenance" });

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 24, EmployeeId = 6, ProjectId = 4, Date = new DateTime(2022, 02, 28), WorkedHours = 8, Note = "Testing" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 25, EmployeeId = 6, ProjectId = 4, Date = new DateTime(2022, 03, 01), WorkedHours = 8, Note = "Testing" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 25, EmployeeId = 6, ProjectId = 3, Date = new DateTime(2022, 03, 02), WorkedHours = 8, Note = "Testing" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 25, EmployeeId = 6, ProjectId = 4, Date = new DateTime(2022, 03, 03), WorkedHours = 8, Note = "Testing" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 25, EmployeeId = 6, ProjectId = 3, Date = new DateTime(2022, 03, 04), WorkedHours = 8, Note = "Testing" });
        }
    }
}
