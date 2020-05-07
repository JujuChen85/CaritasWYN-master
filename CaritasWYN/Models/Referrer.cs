using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaritasWYN.Models
{
    public class Referrer
    {
        [Key]
        public int ReferrerId { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Type")]
        [StringLength(50)]
        public string Type { get; set; }
        [Display(Name = "Phone")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Display(Name = "Office")]
        [StringLength(50)]
        public string Office { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
