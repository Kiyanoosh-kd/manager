using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace UniqueApi.Entities;

public class Equipment
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Guid EquipmentTypeId { get; private set; }

    public EquipmentType EquipmentType { get; private set; }

    public bool IsEnabled { get; private set; }

    public Equipment(
        string name,
        EquipmentType equipmentType)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(Name));
        ArgumentNullException.ThrowIfNull(equipmentType);

        Id = Guid.NewGuid();
        Name = name.Trim();
        EquipmentTypeId = equipmentType.Id;
        EquipmentType = equipmentType;
        IsEnabled = true;
    }

    public void Enable()
    {
        IsEnabled = true;
    }

    public void Disable()
    {
        IsEnabled = false;
    }
}

