using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Data.Repository;
using WebApplicationProject.Models;

namespace WebApplicationProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebApplicationProjectContext _context;
        private IGenericRepository<Album> albumRepository;
        private IGenericRepository<Artist> artistRepository;
        private IGenericRepository<Band> bandRepository;
        private IGenericRepository<BandArtist> bandArtistRepository;
        private IGenericRepository<Gebruiker> gebruikerRepository;
        private IGenericRepository<Genre> genreRepository;
        private IGenericRepository<Review> reviewRepository;
        private IGenericRepository<Role> roleRepository;
        private IGenericRepository<Song> songRepository;


        public UnitOfWork(WebApplicationProjectContext context)
        {
            _context = context;
        }

        public IGenericRepository<Album> AlbumRepository
        {
            get
            {
                if (this.albumRepository == null)
                {
                    this.albumRepository = new GenericRepository<Album>(_context);
                }
                return albumRepository;
            }
        }

        public IGenericRepository<Artist> ArtistRepository
        {
            get
            {
                if (this.artistRepository == null)
                {
                    this.artistRepository = new GenericRepository<Artist>(_context);
                }
                return artistRepository;
            }
        }

        public IGenericRepository<Band> BandRepository
        {
            get
            {
                if (this.bandRepository == null)
                {
                    this.bandRepository = new GenericRepository<Band>(_context);
                }
                return bandRepository;
            }
        }

        public IGenericRepository<BandArtist> BandArtistRepository
        {
            get
            {
                if (this.bandArtistRepository == null)
                {
                    this.bandArtistRepository = new GenericRepository<BandArtist>(_context);
                }
                return bandArtistRepository;
            }
        }

        public IGenericRepository<Gebruiker> GebruikerRepository
        {
            get
            {
                if (this.gebruikerRepository == null)
                {
                    this.gebruikerRepository = new GenericRepository<Gebruiker>(_context);
                }
                return gebruikerRepository;
            }
        }

        public IGenericRepository<Genre> GenreRepository
        {
            get
            {
                if (this.genreRepository == null)
                {
                    this.genreRepository = new GenericRepository<Genre>(_context);
                }
                return genreRepository;
            }
        }

        public IGenericRepository<Review> ReviewRepository
        {
            get
            {
                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new GenericRepository<Review>(_context);
                }
                return reviewRepository;
            }
        }

        public IGenericRepository<Role> RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<Role>(_context);
                }
                return roleRepository;
            }
        }

        public IGenericRepository<Song> SongRepository
        {
            get
            {
                if (this.songRepository == null)
                {
                    this.songRepository = new GenericRepository<Song>(_context);
                }
                return songRepository;
            }
        }
        //public IGenericRepository<Album> AlbumRepository => throw new NotImplementedException();

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
