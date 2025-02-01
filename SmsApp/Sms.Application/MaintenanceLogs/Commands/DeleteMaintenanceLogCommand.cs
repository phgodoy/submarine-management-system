using MediatR;

namespace Sms.Application.MaintenanceLogs.Commands
{
    public class DeleteMaintenanceLogCommand : IRequest
    {
        public int Id { get; }

        public DeleteMaintenanceLogCommand(int id)
        {
            Id = id;
        }
    }
}
