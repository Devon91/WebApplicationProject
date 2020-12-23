using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public partial class Band
    {
        public int BandID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Background { get; set; }
        public List<Album> Albums { get; set; }
        public List<BandArtist> BandArtists { get; set; }
    }
}
