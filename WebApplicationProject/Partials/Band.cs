using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public partial class Band
    {
        public override bool Equals(object obj)
        {
            return obj is Band band
                && Name.ToLower() == band.Name.ToLower();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
