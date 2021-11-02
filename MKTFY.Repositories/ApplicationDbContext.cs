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
    }
}
