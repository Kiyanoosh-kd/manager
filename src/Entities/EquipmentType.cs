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
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Equipment type name cannot be empty.",
                nameof(name));

        Id = Guid.NewGuid();
        Name = name.Trim();
        Description = description;
    }
}

