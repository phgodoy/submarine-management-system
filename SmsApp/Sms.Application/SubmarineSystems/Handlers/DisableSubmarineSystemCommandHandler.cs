using MediatR;
using Sms.Application.SubmarineSystems.Commands;
using Sms.Domain.Interfaces;

namespace Sms.Application.SubmarineSystems.Handlers
{
    public class DisableSubmarineSystemCommandHandler : IRequestHandler<UpdateOperationalSystemCommand, bool>
    {
        private readonly ISubmarineSystemRepository _submarineSystemRepository;

        public DisableSubmarineSystemCommandHandler(ISubmarineSystemRepository submarineSystemRepository)
        {
            _submarineSystemRepository = submarineSystemRepository ?? throw new ArgumentNullException(nameof(submarineSystemRepository));
        }

        public async Task<bool> Handle(UpdateOperationalSystemCommand request, CancellationToken cancellationToken)
        {
            var system = await _submarineSystemRepository.GetSubmarineSystemsById(request.Id);
            if (system == null) return false;

            return await _submarineSystemRepository.DisableSubmarineSystem(system.ID);
        }
    }
}
