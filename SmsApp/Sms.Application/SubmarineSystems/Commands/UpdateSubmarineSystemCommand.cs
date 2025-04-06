using MediatR;
using Sms.Domain.Enums;

namespace Sms.Application.SubmarineSystems.Commands
{
    public class UpdateSubmarineSystemCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int SubmarineId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public SystemStatusEnum SystemStatusId { get; set; }
        public DateTime LastMaintenanceDate { get; set; }

        public UpdateSubmarineSystemCommand(
            int id,
            int submarineId,
            string name,
            string type,
            SystemStatusEnum systemStatusId,
            DateTime lastMaintenanceDate)
        {
            Id = id;
            SubmarineId = submarineId;
            Name = name;
            Type = type;
            SystemStatusId = systemStatusId;
            LastMaintenanceDate = lastMaintenanceDate;
        }
    }
}
