using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations;

public class EquipmentTypeConfiguration : IEntityTypeConfiguration<EquipmentType>
{
    public void Configure(
   EntityTypeBuilder<EquipmentType> builder)
    {
        builder.ToTable("EquipmentType");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired();

    }
}
