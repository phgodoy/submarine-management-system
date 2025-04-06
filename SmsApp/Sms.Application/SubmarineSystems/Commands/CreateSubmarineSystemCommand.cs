using MediatR;
using Sms.Domain.Enums;
using Sms.Domain.Entities;

namespace Sms.Application.SubmarineSystems.Commands
{
    public class CreateSubmarineSystemCommand : IRequest<SubmarineSystem>
    {
        public int SubmarineId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public SystemStatusEnum SystemStatusId { get; set; }
        public DateTime LastMaintenanceDate { get; set; }

        public CreateSubmarineSystemCommand(int submarineId, string name, string type, SystemStatusEnum systemStatusId, DateTime lastMaintenanceDate)
        {
            SubmarineId = submarineId;
            Name = name;
            Type = type;
            SystemStatusId = systemStatusId;
            LastMaintenanceDate = lastMaintenanceDate;
        }
    }
}
