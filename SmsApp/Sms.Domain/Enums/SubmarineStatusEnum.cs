using System.ComponentModel;

namespace Sms.Domain.Enums
{
    public enum SubmarineStatusEnum
    {
        // Submarine in active operation
        [Description("InOperation")]
        InOperation = 1,

        // Submarine under maintenance
        [Description("UnderMaintenance")]
        UnderMaintenance = 2,

        // Submarine in reserve
        [Description("InReserve")]
        InReserve = 3,

        // Submarine deactivated
        [Description("Deactivated")]
        Deactivated = 4,

        // Submarine decommissioned
        [Description("Decommissioned")]
        Decommissioned = 5,

        // Submarine lost
        [Description("Lost")]
        Lost = 6,

        // Submarine under construction
        [Description("UnderConstruction")]
        UnderConstruction = 7,

        // Submarine in a museum
        [Description("Museum")]
        Museum = 8
    }
}