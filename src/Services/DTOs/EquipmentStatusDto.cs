using Entities.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs;

public sealed class EquipmentStatusDto
{
    public string Name { get; init; } = string.Empty;

    public EquipmentStatusType Status { get; init; } = EquipmentStatusType.Unknown;

    public decimal PowerConsumption { get; init; } = default(decimal);
}
