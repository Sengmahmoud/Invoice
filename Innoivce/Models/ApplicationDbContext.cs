using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Innoivce.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Innvoice> Innvoices { get; set; }
        public DbSet<ProductInnvoice> ProductInnvoices { get; set; }
        public ApplicationDbContext()
            : base("Connection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductInnvoice>().HasKey(pc => new
            {
                pc.InnvoiceId,
                pc.ProductId
            });
        }
            public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}