using MediatR;
using Sms.Application.SubmarineSystems.Commands;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;

namespace Sms.Application.SubmarineSystems.Handlers
{
    public class CreateSubmarineSystemCommandHandler : IRequestHandler<CreateSubmarineSystemCommand, SubmarineSystem>
    {
        private readonly ISubmarineSystemRepository _repository;

        public CreateSubmarineSystemCommandHandler(ISubmarineSystemRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<SubmarineSystem> Handle(CreateSubmarineSystemCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "The request cannot be null.");

            var submarineSystem = new SubmarineSystem(
                request.SubmarineId,
                request.Name,
                request.Type,
                request.SystemStatusId,
                request.LastMaintenanceDate
            );

            return await _repository.CreateSubmarineSystem(submarineSystem);
        }
    }
}
