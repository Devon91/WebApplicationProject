using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.ViewModels
{
    public class AlbumsViewModel
    {
        public Album Album { get; set; }
        public IEnumerable<Album> Albums { get; set; }
    }
}
