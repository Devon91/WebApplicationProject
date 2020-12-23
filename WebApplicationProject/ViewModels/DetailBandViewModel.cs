using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.ViewModels
{
    public class DetailBandViewModel
    {
        public IEnumerable<Band> Bands { get; set; }
        public Band Band { get; set; }
        public IEnumerable<BandArtist> BandArtists { get; set; }
        public string JoinDate { get; set; }
    }
}
