using MediatR;
using Sms.Application.Submarines.Commands;
using Sms.Domain.Interfaces;


namespace Sms.Application.Submarines.Handlers
{
    public class DisableSubmarineCommandHandler : IRequestHandler<UpdateSubmarineStatusCommand, bool>
    {
        private readonly ISubmarineRepository _submarineRepository;

        public DisableSubmarineCommandHandler(ISubmarineRepository submarineRepository)
        {
            _submarineRepository = submarineRepository ?? throw new ArgumentNullException(nameof(submarineRepository));
        }

        public async Task<bool> Handle(UpdateSubmarineStatusCommand request, CancellationToken cancellationToken)
        {
            var submarine = await _submarineRepository.GetSubmarineById(request.Id);
            if (submarine == null) return false;

            return await _submarineRepository.DisableSubmarine(submarine.ID);
        }
    }
}
