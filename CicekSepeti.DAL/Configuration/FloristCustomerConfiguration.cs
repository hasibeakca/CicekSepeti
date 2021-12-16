using CicekSepeti.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Configuration
{
    public class FloristCustomerConfiguration : IEntityTypeConfiguration<FloristCustomer>
    {
        public void Configure(EntityTypeBuilder<FloristCustomer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.FloristId).IsRequired();

            builder.HasOne(p => p.FloristFK).WithMany(p => p.FloristCustomers).HasForeignKey(p => p.FloristId);
            builder.HasOne(p => p.CustomerFK).WithMany(p => p.FloristCustomers).HasForeignKey(p => p.CustomerId);


        }
    }
}
