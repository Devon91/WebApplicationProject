using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public partial class Artist
    {
        public override bool Equals(object obj)
        {
            return obj is Artist artist
                && FirstName.ToLower() == artist.FirstName.ToLower()
                && LastName.ToLower() == artist.LastName.ToLower();
            //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}
