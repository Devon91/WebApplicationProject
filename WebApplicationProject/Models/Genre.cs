using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}
