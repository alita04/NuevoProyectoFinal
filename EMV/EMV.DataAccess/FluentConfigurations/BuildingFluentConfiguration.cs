using Enviromental_Measurement.Domain.Entities.Structures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Measurement.DataAccess.FluentConfigurations
{
     public class BuildingFluentConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Buildings");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.BuildingNumber)
                .IsRequired();


            builder.OwnsOne(e => e.Address); // value objets


            //builder.HasMany(b => b.Floors).WithOne(f => f.Building).HasForeignKey(f => f.BuildingId);

            

        }

    }
}
