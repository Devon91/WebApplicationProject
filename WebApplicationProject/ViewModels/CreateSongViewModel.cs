using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.ViewModels
{
    public class CreateSongViewModel
    {
        public Song Song { get; set; }
        public int AlbumID { get; set; }
        public SelectList Albums { get; set; }
    }
}
