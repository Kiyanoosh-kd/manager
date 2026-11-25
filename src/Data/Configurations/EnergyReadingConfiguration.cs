using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations;

public class EnergyReadingConfiguration : IEntityTypeConfiguration<EquipmentReading>
{
    public void Configure(
       EntityTypeBuilder<EquipmentReading> builder)
    {
        builder.ToTable("EquipmentReading");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.PowerValue)
            .HasPrecision(18, 4);

        builder.HasOne(e => e.Equipment)
            .WithMany(et => et.Readings)
            .HasForeignKey(e => e.EquipmentId);
    }
}
