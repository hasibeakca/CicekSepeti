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
    public class FloristFlowerConfiguration : IEntityTypeConfiguration<FloristFlower>
    {
        public void Configure(EntityTypeBuilder<FloristFlower> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.FloristFK).WithMany(p => p.FloristFlowers).HasForeignKey(p => p.FloristId);
            builder.HasOne(p => p.FlowerFK).WithMany(p => p.FloristFlowers).HasForeignKey(p => p.FlowerId);
        }
    }
}
