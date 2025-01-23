using Enviromental_Measurement.DataAccess.Repositories;
using Enviromental_Measurement.Domain.Entities.Samples;
using Enviromental_Measurement.Domain.Entities.Structures;
using Enviromental_Measurement.Domain.Entities.Variable;
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
    public class VariableEntityTypeConfigurationBase : IEntityTypeConfiguration<Variable>
    {
            public void Configure(EntityTypeBuilder<Variable> builder)
            {
                builder.ToTable("Variables");

                builder.HasKey(v => v.Id);
    
            builder.Property(v => v.VariableName)
                .IsRequired();


            builder.OwnsOne(e => e.unit);


            builder.Property(v => v.VariableCode)
                .IsRequired();
                    

                builder.Property(v => v.type)
                    .IsRequired();

                // Relationships
                builder.HasMany<Sample>()
                    .WithOne()
                    .HasForeignKey(s => s.VariableId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne<Building>()
                .WithMany()
                .HasForeignKey(v => v.BuildingID)
                .OnDelete(DeleteBehavior.Cascade);


                  builder.HasOne<Floor>()
                 .WithMany()
                 .HasForeignKey(v => v.FloorID)
                .OnDelete(DeleteBehavior.Cascade);

                 builder.HasOne<Room>()
                 .WithMany()
                .HasForeignKey(v => v.RoomID)
                 .OnDelete(DeleteBehavior.Cascade);

        }
        }
    }







 