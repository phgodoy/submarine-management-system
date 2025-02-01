using MediatR;
using Sms.Application.MaintenanceLogs.Commands;
using Sms.Domain.Interfaces;

namespace Sms.Application.MaintenanceLogs.Handlers
{
    public class DeleteMaintenanceLogCommandHandler : IRequestHandler<DeleteMaintenanceLogCommand>
    {
        private readonly IMaintenanceLogRepository _maintenanceLogRepository;

        public DeleteMaintenanceLogCommandHandler(IMaintenanceLogRepository maintenanceLogRepository)
        {
            _maintenanceLogRepository = maintenanceLogRepository;
        }

        public async Task Handle(DeleteMaintenanceLogCommand request, CancellationToken cancellationToken)
        {
            var maintenanceLog = await _maintenanceLogRepository.GetByIdAsync(request.Id);
            if (maintenanceLog == null)
            {
                throw new ApplicationException($"MaintenanceLog with ID {request.Id} not found.");
            }

            await _maintenanceLogRepository.DeleteAsync(maintenanceLog.ID);
        }
    }
}
