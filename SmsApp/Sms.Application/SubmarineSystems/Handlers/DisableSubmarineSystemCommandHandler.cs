
using MediatR;
using Sms.Application.SubmarineSystems.Commands;
using Sms.Domain.Interfaces;

namespace Sms.Application.SubmarineSystems.Handlers
{
    public class DisableSubmarineSystemCommandHandler : IRequestHandler<DisableSubmarineSystemCommand, bool>
    {
        private readonly ISubmarineSystemRepository _repository;

        public DisableSubmarineSystemCommandHandler(ISubmarineSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DisableSubmarineSystemCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "The command cannot be null.");

            // Persist changes
            var updateResult = await _repository.DisableSubmarineSystem(request.Id);

            // Return whether the update was successful
            return updateResult;
        }
    }

}
