using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.MaintenanceLogs.Commands
{
    public class GetMaintenanceLogByIdCommand : IRequest<MaintenanceLog>
    {
        public int Id { get; }

        public GetMaintenanceLogByIdCommand(int id)
        {
            Id = id;
        }
    }
}
