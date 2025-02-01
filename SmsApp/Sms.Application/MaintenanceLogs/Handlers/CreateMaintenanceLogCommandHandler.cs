using MediatR;
using Sms.Application.MaintenanceLogs.Commands;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;

namespace Sms.Application.MaintenanceLogs.Handlers
{
    public class CreateMaintenanceLogCommandHandler : IRequestHandler<CreateMaintenanceLogCommand, MaintenanceLog>
    {
        private readonly IMaintenanceLogRepository _maintenanceLogRepository;

        public CreateMaintenanceLogCommandHandler(IMaintenanceLogRepository maintenanceLogRepository)
        {
            _maintenanceLogRepository = maintenanceLogRepository;
        }

        public async Task<MaintenanceLog> Handle(CreateMaintenanceLogCommand request, CancellationToken cancellationToken)
        {
            var maintenanceLog = new MaintenanceLog(
                request.SubmarineSystemId,
                request.MaintenanceDate,
                request.TechnicianName,
                request.Notes
            );

            await _maintenanceLogRepository.AddAsync(maintenanceLog);
            return maintenanceLog;
        }
    }
}
