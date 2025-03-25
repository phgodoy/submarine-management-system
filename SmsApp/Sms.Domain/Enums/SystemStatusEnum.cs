using System.ComponentModel;

namespace Sms.Domain.Enums
{
    public enum SystemStatusEnum
    {
        // System in active operation
        [Description("InOperation")]
        InOperation = 1,

        // System is disable
        [Description("Disable")]
        Disable = 2,

        // System committed
        [Description("committed")]
        Committed = 9,
    }
}
