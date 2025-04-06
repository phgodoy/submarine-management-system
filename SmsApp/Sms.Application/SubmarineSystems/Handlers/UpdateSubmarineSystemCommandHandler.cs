using MediatR;
using Sms.Application.SubmarineSystems.Commands;
using Sms.Domain.Interfaces;

namespace Sms.Application.SubmarineSystems.Handlers
{
    public class UpdateSubmarineSystemCommandHandler : IRequestHandler<UpdateSubmarineSystemCommand, bool>
    {
        private readonly ISubmarineSystemRepository _submarineSystemRepository;

        public UpdateSubmarineSystemCommandHandler(ISubmarineSystemRepository submarineSystemRepository)
        {
            _submarineSystemRepository = submarineSystemRepository ?? throw new ArgumentNullException(nameof(submarineSystemRepository));
        }

        public async Task<bool> Handle(UpdateSubmarineSystemCommand request, CancellationToken cancellationToken)
        {
            var submarineSystem = await _submarineSystemRepository.GetSubmarineSystemsById(request.Id);
            if (submarineSystem == null) return false;

            submarineSystem.Update(
                request.SubmarineId,
                request.Name,
                request.Type,
                request.SystemStatusId,
                request.LastMaintenanceDate
            );

            return await _submarineSystemRepository.UpdateSubmarineSystem(submarineSystem);
        }
    }
}
