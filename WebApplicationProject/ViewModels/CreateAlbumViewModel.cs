using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.ViewModels
{
    public class CreateAlbumViewModel
    {
        public Album Album { get; set; }
        public SelectList Genres { get; set; }
        public SelectList Bands { get; set; }
        [Display(Name = "Album Image")]
        public IFormFile CoverArtImage { get; set; }

    }
}
