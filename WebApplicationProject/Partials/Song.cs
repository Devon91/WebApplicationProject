using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public partial class Song
    {
        public override bool Equals(object obj)
        {
            return obj is Song song
                && Title.ToLower() == song.Title.ToLower();
          //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title);
        }
    }
}
