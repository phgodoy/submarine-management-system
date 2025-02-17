using System.ComponentModel;

namespace Sms.Domain.Enums
{
    public enum SubmarineStatusEnum
    {
        // Submarine in active operation
        [Description("EmOperacao")]
        EmOperacao = 1,

        // Submarine under maintenance
        [Description("EmManutencao")]
        EmManutencao = 2,

        // Submarine under maintenance
        [Description("EmReserva")]
        EmReserva = 3,

        // Submarine under maintenance
        [Description("Desativado")]
        Desativado = 4,

        // Submarine under maintenance
        [Description("Descomissionado")]
        Descomissionado = 5,

        // Submarine under maintenance
        [Description("Perdido")]
        Perdido = 6,

        // Submarine under maintenance
        [Description("EmConstrucao")]
        EmConstrucao = 7,

        // Submarine under maintenance
        [Description("Museu")]
        Museu = 8
    }
}