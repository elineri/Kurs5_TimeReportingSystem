using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeReportingSystem.Models
{
    public class TimeReport
    {
        [Key]
        public int TimeReportId { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int WorkedHours { get; set; }
        public string Note { get; set; }
    }
}
