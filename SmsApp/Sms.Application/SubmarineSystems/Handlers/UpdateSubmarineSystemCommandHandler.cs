using MediatR;
using Sms.Application.SubmarineSystems.Commands;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;

namespace Sms.Application.SubmarineSystems.Handlers
{
    public class UpdateSubmarineSystemCommandHandler : IRequestHandler<UpdateSubmarineSystemCommand, SubmarineSystem>
    {
        private readonly ISubmarineSystemRepository _repository;

        public UpdateSubmarineSystemCommandHandler(ISubmarineSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubmarineSystem> Handle(UpdateSubmarineSystemCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing submarine system
            var existingSystem = await _repository.GetSubmarineSystemById(request.Id);

            if (existingSystem == null)
                return null; // Return null to indicate not found (handled by the controller)

            // Update the entity
            existingSystem.Update(
                request.Name,
                request.Type,
                request.OperationalStatus,
                request.LastMaintenanceDate
            );

            // Save changes
            await _repository.Update(existingSystem);

            return existingSystem;
        }
    }
}
