using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }

        //test
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        public string CoverArt { get; set; }
        public int BandID { get; set; }

        public Band Band { get; set; }

        [Display(Name = "Datum aangemaakt")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string MusicLabel { get; set; }
        public int CriticsRating { get; set; }
        public string Producer { get; set; }
        public string Award { get; set; }
        public List<Song> Songs { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
