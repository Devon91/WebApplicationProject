using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.ViewModels
{
    public class ListBandViewModel
    {
        public string BandSearch { get; set; }
        public List<Band> Bands { get; set; }
    }
}
