using Entities.common;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Entities;

public class Equipment : BaseEntity<Guid>
{
    public string Name { get; private set; }

    public Guid EquipmentTypeId { get; private set; }

    public EquipmentType EquipmentType { get; private set; }

    public ICollection<EquipmentReading> Readings { get; private set; } = new List<EquipmentReading>();

    public bool IsEnabled { get; private set; }

    private Equipment()
    {

    }
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

