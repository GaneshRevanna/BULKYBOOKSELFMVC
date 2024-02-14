
using Bulky.models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { 

        }
       public DbSet<Catogiries> Catogiries { get; set; }
        public DbSet<Product>Products  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catogiries>().HasData
                (
                new Catogiries { id = 1, Name = "Sowmya", displayorder = 1 },
                new Catogiries { id = 2, Name = "Ganesh", displayorder = 2 },
                new Catogiries { id = 3, Name = "prf", displayorder = 3 }

                );
            modelBuilder.Entity<Product>().HasData
          (
          new Product { Id = 1, Title = "Best Of world", Description = "good book", ISBN = "hsv", author = "Ansi", ListPrice = 1000, Price = 20, Price50 = 1000, Price100 = 2000, CategoryId=1,Imageurl="" },
          new Product { Id = 2, Title = "Best Of Nature", Description = "Fantastic book", ISBN = "hsv", author = "Ramakrishna", ListPrice = 1000, Price = 20, Price50 = 1000, Price100 = 2000, CategoryId=1 ,Imageurl = "" },
          new Product { Id = 3, Title = "Best Of earth", Description = "Crazy Book", ISBN = "hsv", author = "krishna", ListPrice = 1000, Price = 20, Price50 = 1000, Price100 = 2000, CategoryId=1 , Imageurl = "" }

          );
        }
    }
   
}



