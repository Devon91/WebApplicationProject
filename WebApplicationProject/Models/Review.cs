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
        public int ReviewRating { get; set; }
        public User User { get; set; }
    }
}
