using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;
public sealed class EnergyDbContext : DbContext
{
    public EnergyDbContext(DbContextOptions<EnergyDbContext> options)
    : base(options)
    {

    }

    public DbSet<Equipment> Equipments => Set<Equipment>();
    public DbSet<EquipmentType> EquipmentTypes => Set<EquipmentType>();
    public DbSet<EquipmentReading> EquipmentReadings => Set<EquipmentReading>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(EnergyDbContext).Assembly);
    }

}
