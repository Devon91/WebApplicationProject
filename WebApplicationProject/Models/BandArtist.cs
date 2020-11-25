using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public class BandArtist
    {
        public int BandArtistID { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public int ArtistID { get; set; }
        public int RoleID { get; set; }
        public int BandID { get; set; }
        public Role Role { get; set; }
        public Band Band { get; set; }
        public Artist Artist { get; set; }
    }
}
