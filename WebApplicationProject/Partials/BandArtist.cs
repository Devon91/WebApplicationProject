using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public partial class BandArtist
    {
        public override bool Equals(object obj)
        {
            return obj is BandArtist bandArtist
                && Artist.ArtistID == bandArtist.Artist.ArtistID
                && RoleID == bandArtist.RoleID
                //&& Artist.LastName.ToLower() == bandArtist.Artist.LastName.ToLower()
                && bandArtist.BandID == bandArtist.BandID;
            //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ArtistID, RoleID, BandID);
        }
    }
}
