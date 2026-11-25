using Entities.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs;

public sealed class EnergyStatusResponse
{
    public DateTime Timestamp { get; init; }

    public IReadOnlyList<EquipmentStatusDto> Equipment { get; init; } = Array.Empty<EquipmentStatusDto>();
}
