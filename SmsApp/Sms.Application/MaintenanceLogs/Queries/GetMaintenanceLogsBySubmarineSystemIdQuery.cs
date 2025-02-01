using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.MaintenanceLogs.Queries
{
    public class GetMaintenanceLogsBySubmarineSystemIdQuery : IRequest<IEnumerable<MaintenanceLog>>
    {
        public int SubmarineSystemId { get; }

        public GetMaintenanceLogsBySubmarineSystemIdQuery(int submarineSystemId)
        {
            SubmarineSystemId = submarineSystemId;
        }
    }
}
