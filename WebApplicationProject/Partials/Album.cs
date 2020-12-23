using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public partial class Album
    {
        public override bool Equals(object obj)
        {
            return obj is Album album
                && Title.ToLower() == album.Title.ToLower()
                && BandID == album.BandID;
            //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, BandID);
        }
    }
}
