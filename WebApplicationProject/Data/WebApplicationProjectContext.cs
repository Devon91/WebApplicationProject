using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Areas.Identity.Data;
using WebApplicationProject.Models;

namespace WebApplicationProject.Data
{
    public class WebApplicationProjectContext : IdentityDbContext<CustomUser>
    {
        public WebApplicationProjectContext(DbContextOptions<WebApplicationProjectContext> options) : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<BandArtist> BandArtists { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Role> ArtistRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("project");

            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Song>().ToTable("Song");
            modelBuilder.Entity<Gebruiker>().ToTable("User");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Band>().ToTable("Band");
            modelBuilder.Entity<BandArtist>().ToTable("BandArtist");
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<Role>().ToTable("Role");
        }
    }
}
