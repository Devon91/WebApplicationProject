using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public partial class Song
    {
        public int SongID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int TrackLength { get; set; }
        public Album Album { get; set; }
        public int AlbumID { get; set; }
        [Required]
        public int TrackNumber { get; set; }
    }
}
