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
    public class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.ToTable("Floors");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Location)
                .IsRequired();
                

            builder.HasOne<Building>()
                .WithMany()
                .HasForeignKey(p => p.Building_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}