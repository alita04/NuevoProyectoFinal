using EMV.DataAccess.FluentConfigurations.Common;
using EMV.Domain.Entities.Samples;
using Enviromental_Measurement.Domain.Entities.Variable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.DataAccess.FluentConfigurations
{
    public class SampleEntityTypeConfigurationBase : EntityTypeConfigurationBase<Sample>
    {
        public override void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.ToTable("Samples");

            builder.HasKey(r => r.Id);

            builder.Property(y => y.DateTime).IsRequired();
            builder.Property(y => y.type).IsRequired();
            builder.Property(y => y.VariableId).IsRequired();
            
            builder.Property( y => y.DecimalValue)
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            builder.Property(y => y.IntValue)
                .IsRequired(false);

            builder.Property(y => y.BoolValue)
                .IsRequired(false);

           builder.HasOne<Variable>()
                .WithMany()
                .HasForeignKey( y => y.VariableId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
