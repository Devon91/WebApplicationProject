using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<BandArtist> BandArtists  { get; set; }
    }
}
