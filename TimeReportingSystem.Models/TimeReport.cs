using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required(ErrorMessage = "Date is required")]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Worked hours is required")]
        [Range(0, 24, ErrorMessage = "Worked hours must be between 0-24")]
        public int WorkedHours { get; set; }

        [StringLength(50, MinimumLength = 0, ErrorMessage = "Note can't be longer than 25 characters")]
        public string Note { get; set; }
    }
}
