using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.Areas.Identity.Data
{
    public class CustomUser : IdentityUser
    {
        [PersonalData]
        public Gebruiker Gebruiker { get; set; }
    }
}
