using CicekSepeti.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Context
{
    public class CicekSepetiDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-M227QJH7\\SQLEXPRESS;Database=CicekSepetiDB;Trusted_Connection=True;");
        }
        public DbSet<Florist> Florists { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FloristCustomer> FloristCustomers { get; set; }
        public DbSet<FloristFlower> FloristFlowers { get; set; }
    }
}
