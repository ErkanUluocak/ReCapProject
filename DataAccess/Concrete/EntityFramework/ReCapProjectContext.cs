using DataAccess.Configuration;
using Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapProject;Trusted_Connection=true;");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Car>()
            .Property(o => o.DailyPrice).HasColumnType("decimal(22,2)");

            modelBuilder.ApplyConfiguration(new BrandCFG());
            modelBuilder.ApplyConfiguration(new CarCFG());
            modelBuilder.ApplyConfiguration(new ColorCFG());

            modelBuilder.ApplyConfiguration(new UserCFG());
            modelBuilder.ApplyConfiguration(new CustomerCFG());

            base.OnModelCreating(modelBuilder);
        }

    }
}
