using Microsoft.EntityFrameworkCore;
using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            // This is where we use the Fluent API to have finer control over the database setup.
            // Anything you can do with data annotations on the entity models can also be done
            // with the Fluent API

        }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<User> Users { get; set; }
        public virtual DbSet<FAQ> FAQ { get; set; }
        public DbSet<Upload> Uploads { get; set; }

        public DbSet<ListingUpload> ListingUploads { get; set; }
        public DbSet<SearchItem> SearchItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ListingUpload>()
               .HasKey(e => new { e.ListingId, e.UploadId });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Cars & Vehicles" },
                new Category { Id = 2, Name = "Furniture" },
                new Category { Id = 3, Name = "Electronics" },
                new Category { Id = 4, Name = "Real Estate" }

            );
        }


    }
}
