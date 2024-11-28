using MediatR;
using Sms.Application.Commands;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;

namespace Sms.Application.SubmarineSystems.Handlers
{
    public class CreateSubmarineSystemCommandHandler : IRequestHandler<CreateSubmarineSystemCommand, SubmarineSystem>
    {
        private readonly ISubmarineSystemRepository _repository;

        public CreateSubmarineSystemCommandHandler(ISubmarineSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubmarineSystem> Handle(CreateSubmarineSystemCommand request, CancellationToken cancellationToken)
        {
            var submarineSystem = new SubmarineSystem(
                request.Name,
                request.Type,
                request.OperationalStatus,
                request.LastMaintenanceDate
            );

            return await _repository.Create(submarineSystem);
        }
    }
}
