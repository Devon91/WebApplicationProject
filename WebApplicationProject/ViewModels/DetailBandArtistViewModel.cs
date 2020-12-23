using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.ViewModels
{
    public class DetailBandArtistViewModel
    {
        public IEnumerable<Band> Bands { get; set; }
    }
}
