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

        //public IGenericRepository<Album> AlbumRepository => throw new NotImplementedException();

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
