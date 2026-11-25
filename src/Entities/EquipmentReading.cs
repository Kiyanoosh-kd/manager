using Entities.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities;

public class EquipmentReading : BaseEntity<Guid>
{
    public Guid EquipmentId { get; private set; }

    public EquipmentStatusType Status { get; private set; }

    public decimal PowerValue { get; private set; }

    public PowerUnitType PowerUnit { get; private set; }

    public DateTime ObservedAtUtc { get; private set; }
    public Equipment? Equipment { get; private set; }

    public EquipmentReading(
        Guid equipmentId,
        EquipmentStatusType status,
        decimal powerValue,
        PowerUnitType powerUnit)
    {

        if (equipmentId == Guid.Empty)
            throw new ArgumentException("Equipment ID cannot be empty.", nameof(equipmentId));

        if (!Enum.IsDefined(status))
            throw new ArgumentException(
                $"Invalid equipment status: {status}",
                nameof(status));

        ArgumentOutOfRangeException.ThrowIfNegative(powerValue);

        if (!Enum.IsDefined(powerUnit))
            throw new ArgumentException(
                $"Invalid power unit: {powerUnit}",
                nameof(powerUnit));


        Id = Guid.NewGuid();
        EquipmentId = equipmentId;
        Status = status;
        PowerValue = powerValue;
        PowerUnit = powerUnit;
        ObservedAtUtc = DateTime.UtcNow;
    }
}