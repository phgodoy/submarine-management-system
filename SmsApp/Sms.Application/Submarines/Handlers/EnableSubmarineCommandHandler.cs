using MediatR;
using Sms.Application.Submarines.Commands;
using Sms.Domain.Interfaces;

namespace Sms.Application.Submarines.Handlers
{
    public class EnableSubmarineCommandHandler : IRequestHandler<UpdateSubmarineStatusCommand, bool>
    {
        private readonly ISubmarineRepository _submarineRepository;

        public EnableSubmarineCommandHandler(ISubmarineRepository submarineRepository)
        {
            _submarineRepository = submarineRepository ?? throw new ArgumentNullException(nameof(submarineRepository));
        }

        public async Task<bool> Handle(UpdateSubmarineStatusCommand request, CancellationToken cancellationToken)
        {
            var submarine = await _submarineRepository.GetSubmarineById(request.Id);
            if (submarine == null) return false;

            return await _submarineRepository.EnableSubmarine(submarine.ID);
        }
    }
}
