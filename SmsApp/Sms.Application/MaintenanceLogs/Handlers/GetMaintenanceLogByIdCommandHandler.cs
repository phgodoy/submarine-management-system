using MediatR;
using Sms.Application.MaintenanceLogs.Commands;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;

namespace Sms.Application.MaintenanceLogs.Handlers
{
    public class GetMaintenanceLogByIdCommandHandler : IRequestHandler<GetMaintenanceLogByIdCommand, MaintenanceLog>
    {
        private readonly IMaintenanceLogRepository _maintenanceLogRepository;

        public GetMaintenanceLogByIdCommandHandler(IMaintenanceLogRepository maintenanceLogRepository)
        {
            _maintenanceLogRepository = maintenanceLogRepository;
        }

        public async Task<MaintenanceLog> Handle(GetMaintenanceLogByIdCommand request, CancellationToken cancellationToken)
        {
            var maintenanceLog = await _maintenanceLogRepository.GetByIdAsync(request.Id);
            if (maintenanceLog == null)
            {
                throw new ApplicationException($"MaintenanceLog with ID {request.Id} not found.");
            }

            return maintenanceLog;
        }
    }
}
