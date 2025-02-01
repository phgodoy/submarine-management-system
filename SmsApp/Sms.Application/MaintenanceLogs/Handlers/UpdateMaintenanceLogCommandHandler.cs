using MediatR;
using Sms.Application.MaintenanceLogs.Commands;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;

namespace Sms.Application.MaintenanceLogs.Handlers
{
    public class UpdateMaintenanceLogCommandHandler : IRequestHandler<UpdateMaintenanceLogCommand, MaintenanceLog>
    {
        private readonly IMaintenanceLogRepository _maintenanceLogRepository;

        public UpdateMaintenanceLogCommandHandler(IMaintenanceLogRepository maintenanceLogRepository)
        {
            _maintenanceLogRepository = maintenanceLogRepository;
        }

        public async Task<MaintenanceLog> Handle(UpdateMaintenanceLogCommand request, CancellationToken cancellationToken)
        {
            var maintenanceLog = await _maintenanceLogRepository.GetByIdAsync(request.Id);
            if (maintenanceLog == null)
            {
                throw new ApplicationException($"MaintenanceLog with ID {request.Id} not found.");
            }

            maintenanceLog.Update(
                request.SubmarineSystemId,
                request.MaintenanceDate,
                request.TechnicianName,
                request.Notes
            );

            await _maintenanceLogRepository.UpdateAsync(maintenanceLog);
            return maintenanceLog;
        }
    }
}
