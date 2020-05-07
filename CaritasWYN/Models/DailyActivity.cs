using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaritasWYN.Models
{
    public class DailyActivity
    {
        [Key]
        public int DailyActivityId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int? Act_typeId { get; set; }
        public Act_type Act_Type { get; set; }
        public Staff Staff { get; set; }
        public int? StaffId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
