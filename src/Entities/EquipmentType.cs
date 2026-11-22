using System;
using System.Collections.Generic;
using System.Text;

namespace UniqueApi.Entities;

public class EquipmentType
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string? Description { get; private set; }


    public EquipmentType(string name, string? description = null)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(Name));

        Id = Guid.NewGuid();
        Name = name.Trim();
        Description = description;
    }
}

