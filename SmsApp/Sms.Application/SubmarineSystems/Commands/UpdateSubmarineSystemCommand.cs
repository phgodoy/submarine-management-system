using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.SubmarineSystems.Commands
{
    public class UpdateSubmarineSystemCommand : IRequest<SubmarineSystem>
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Type { get; }
        public string OperationalStatus { get; }
        public DateTime LastMaintenanceDate { get; }

        public UpdateSubmarineSystemCommand(int id, string name, string type, string operationalStatus, DateTime lastMaintenanceDate)
        {   
            Id = id;
            Name = name;
            Type = type;
            OperationalStatus = operationalStatus;
            LastMaintenanceDate = lastMaintenanceDate;
        }
    }
}
