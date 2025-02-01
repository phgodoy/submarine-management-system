using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.MaintenanceLogs.Commands
{
    public class UpdateMaintenanceLogCommand : IRequest<MaintenanceLog>
    {
        public int Id { get; }
        public int SubmarineSystemId { get; }
        public DateTime MaintenanceDate { get; }
        public string TechnicianName { get; }
        public string Notes { get; }

        public UpdateMaintenanceLogCommand(int id, int submarineSystemId, DateTime maintenanceDate, string technicianName, string notes)
        {
            Id = id;
            SubmarineSystemId = submarineSystemId;
            MaintenanceDate = maintenanceDate;
            TechnicianName = technicianName;
            Notes = notes;
        }
    }
}
