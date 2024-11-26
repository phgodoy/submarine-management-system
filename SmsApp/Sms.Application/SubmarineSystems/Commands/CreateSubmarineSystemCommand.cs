using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.Commands
{
    public class CreateSubmarineSystemCommand : IRequest<SubmarineSystem>
    {
        public string Name { get; }
        public string Type { get; }
        public string OperationalStatus { get; }
        public DateTime LastMaintenanceDate { get; }

        public CreateSubmarineSystemCommand(string name, string type, string operationalStatus, DateTime lastMaintenanceDate)
        {
            Name = name;
            Type = type;
            OperationalStatus = operationalStatus;
            LastMaintenanceDate = lastMaintenanceDate;
        }
    }
}
