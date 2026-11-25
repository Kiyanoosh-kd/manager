using Entities.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities;

public class EquipmentType : BaseEntity<Guid>
{
    public string Name { get; private set; }

    public string? Description { get; private set; }

    public ICollection<Equipment> Equipments { get; private set; } = new List<Equipment>();

    public EquipmentType(string name, string? description = null)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(Name));

        Id = Guid.NewGuid();
        Name = name.Trim();
        Description = description;
    }
}

