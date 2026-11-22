using System;
using System.Collections.Generic;
using System.Text;

namespace UniqueApi.Entities;

public class EquipmentReading
{
    public Guid Id { get; private set; }

    public Guid EquipmentId { get; private set; }

    public string Status { get; private set; }

    public decimal PowerValue { get; private set; }

    public string PowerUnit { get; private set; }

    public DateTime ObservedAtUtc { get; private set; }


    public EquipmentReading(
        Guid equipmentId,
        string status,
        decimal powerValue,
        string powerUnit)
    {

        if (equipmentId == Guid.Empty)
            throw new ArgumentException("Equipment ID cannot be empty.", nameof(equipmentId));

        ArgumentNullException.ThrowIfNullOrWhiteSpace(status, nameof(Status));
        ArgumentOutOfRangeException.ThrowIfNegative(powerValue);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(powerUnit);


        Id = Guid.NewGuid();
        EquipmentId = equipmentId;
        Status = status.Trim();
        PowerValue = powerValue;
        PowerUnit = powerUnit.Trim();
        ObservedAtUtc = DateTime.UtcNow;
    }
}