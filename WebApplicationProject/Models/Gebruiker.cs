using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Areas.Identity.Data;

namespace WebApplicationProject.Models
{
    public class Gebruiker
    {
        public int GebruikerID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public List<Review> Reviews { get; set; }
        public string UserID { get; set; }
        public CustomUser CustomUser { get; set; }
    }
}
