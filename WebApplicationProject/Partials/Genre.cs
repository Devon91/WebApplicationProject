using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public partial class Genre
    {
        public override bool Equals(object obj)
        {
            return obj is Genre genre
                && Name.ToLower() == genre.Name.ToLower();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }


}
