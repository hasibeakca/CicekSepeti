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
    public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
    {
        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Type).IsRequired().HasMaxLength(20);

            builder.HasOne(p => p.CustomerFK).WithMany(p => p.Flowers).HasForeignKey(p => p.CustomerId);
        }
    }
}
