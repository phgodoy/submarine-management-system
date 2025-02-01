using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.MaintenanceLogs.Queries
{
    public class GetMaintenanceLogByIdQuery : IRequest<MaintenanceLog>
    {
        public int Id { get; }

        public GetMaintenanceLogByIdQuery(int id)
        {
            Id = id;
        }
    }
}
