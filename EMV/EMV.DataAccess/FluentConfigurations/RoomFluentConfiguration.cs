using Enviromental_Measurement.Domain.Entities.Structures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Measurement.DataAccess.FluentConfigurations
{
    internal class RoomFluentConfiguration : IEntityTypeConfiguration<Room>
    {
        public  void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Number).IsRequired();
            builder.Property(r => r.IsProduction).IsRequired();

            builder.HasOne<Floor>()
               .WithMany()
               .HasForeignKey(r => r.FloorId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
