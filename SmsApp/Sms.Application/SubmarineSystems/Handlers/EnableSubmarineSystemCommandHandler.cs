using MediatR;
using Sms.Application.SubmarineSystems.Commands;
using Sms.Domain.Interfaces;


namespace Sms.Application.SubmarineSystems.Handlers
{
    public class EnableSubmarineSystemCommandHandler : IRequestHandler<EnableSubmarineSystemCommand, bool>
    {
        private readonly ISubmarineSystemRepository _repository;

        public EnableSubmarineSystemCommandHandler(ISubmarineSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(EnableSubmarineSystemCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "The command cannot be null.");

            var updateResult = await _repository.EnableSubmarineSystem(request.Id);

            return updateResult;
        }
    }
}
