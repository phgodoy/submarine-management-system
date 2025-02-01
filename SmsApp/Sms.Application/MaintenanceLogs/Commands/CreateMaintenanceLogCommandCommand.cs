using MediatR;
using Sms.Domain.Entities;
using System;

namespace Sms.Application.MaintenanceLogs.Commands
{
    public class CreateMaintenanceLogCommand : IRequest<MaintenanceLog>
    {
        public int SubmarineSystemId { get; }
        public DateTime MaintenanceDate { get; }
        public string TechnicianName { get; }
        public string Notes { get; }

        public CreateMaintenanceLogCommand(int submarineSystemId, DateTime maintenanceDate, string technicianName, string notes)
        {
            SubmarineSystemId = submarineSystemId;
            MaintenanceDate = maintenanceDate;
            TechnicianName = technicianName;
            Notes = notes;
        }
    }
}
