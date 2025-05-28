using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderPackagingService.Domain.Entities;

namespace OrderPackagingService.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } 
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .OwnsOne(p => p.Dimensions, d =>
                {
                    d.Property(dd => dd.Height).HasColumnName("Height");
                    d.Property(dd => dd.Width).HasColumnName("Width");
                    d.Property(dd => dd.Length).HasColumnName("Length");
                });
        }
    }
}
