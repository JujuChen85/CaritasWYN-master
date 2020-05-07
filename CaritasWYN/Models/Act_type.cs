using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaritasWYN.Models
{
    public class Act_type
    {
        [Key]
        public int Act_typeId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Activity Type")]
        public string ActivityName { get; set; }
        public ICollection<DailyActivity> DailyActivities { get; set; }
    }
}
