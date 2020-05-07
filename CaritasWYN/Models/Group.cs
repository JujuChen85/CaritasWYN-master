using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaritasWYN.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public int StaffId { get; set; }
        public int ClientId { get; set; }
        public Staff Staff { get; set; }
        public Client Client { get; set; }
    }
}
