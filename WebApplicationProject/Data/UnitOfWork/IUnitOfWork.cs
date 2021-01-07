using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Data.Repository;
using WebApplicationProject.Models;

namespace WebApplicationProject.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Album> AlbumRepository { get; }
        IGenericRepository<Artist> ArtistRepository { get; }
        IGenericRepository<Band> BandRepository { get; }
        IGenericRepository<BandArtist> BandArtistRepository { get; }
        IGenericRepository<Gebruiker> GebruikerRepository { get; }
        IGenericRepository<Genre> GenreRepository { get; }
        IGenericRepository<Review> ReviewRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }
        IGenericRepository<Song> SongRepository { get; }



        Task Save();
    }
}
