using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.ViewModels
{
    public class CreateReviewViewModel
    {
        public Review Review { get; set; }

        public Gebruiker Gebruiker { get; set; }
        public string UserName { get; set; }
        public Album Album { get; set; }
    }
}
