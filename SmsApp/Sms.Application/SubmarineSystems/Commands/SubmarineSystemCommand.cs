using Sms.Domain.Entities;
using MediatR;

namespace Sms.Application.SubmarineSystems.Commands
{
    public abstract class SubmarineSystemCommand : IRequest<SubmarineSystem>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string OperationalStatus { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
    }
}
