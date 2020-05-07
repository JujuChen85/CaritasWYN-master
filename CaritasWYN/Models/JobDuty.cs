using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaritasWYN.Models
{
    public class JobDuty
    {
        [Key]
        public int JobDutyId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Job Type")]
        public string JobType { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
