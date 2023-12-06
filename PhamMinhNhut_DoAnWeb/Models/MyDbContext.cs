using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace PhamMinhNhut_DoAnWeb.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("myCS") { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<User> User { get; set; }
    }
}