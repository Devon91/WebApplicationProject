using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.ViewModels
{
    public class CreateBandViewModel
    {
        public Band Band { get; set; }
        public BandArtist BandArtist { get; set; }
        //public SelectList Artists { get; set; }
        //public SelectList Roles { get; set; }
    }
}
