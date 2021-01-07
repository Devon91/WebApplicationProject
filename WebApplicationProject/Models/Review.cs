using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        [Required]
        public string Text { get; set; }
        public Album Album { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "value between 0 and 10")]
        public int ReviewRating { get; set; }
        public Gebruiker Gebruiker { get; set; }
    }
}
