using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FreeShop.DataAccess.Abstract.EntityFramework.Context
{
    public class FreeShopDbContext : DbContext
    {
        //Database baglantisini yapiyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FreeShopDatabase;Integrated Security=True;");
        }

        //Database'deki table'lari olusturuyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}
