using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaritasWYN.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

        public int? ReferrerId { get; set; }
        [StringLength(50)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        public string Room { get; set; }
        [StringLength(50)]
        [Display(Name = "Floor")]
        public string Floor { get; set; }
        [StringLength(50)]
        [Display(Name = "Street")]
        public string Street { get; set; }
        [StringLength(50)]
        [Display(Name = "Building")]
        public string Building { get; set; }
        [StringLength(50)]
        [Display(Name = "District")]
        public string District { get; set; }


        public Referrer Referrer { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
