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
        Task Save();
    }
}
