using MediatR;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;

namespace Sms.Application.Submarines.Commands
{
    public class CreateSubmarineCommandHandler : IRequestHandler<CreateSubmarineCommand, Submarine>
    {
        private readonly ISubmarineRepository _submarineRepository;

        public CreateSubmarineCommandHandler(ISubmarineRepository submarineRepository)
        {
            _submarineRepository = submarineRepository;
        }

        public async Task<Submarine> Handle(CreateSubmarineCommand request, CancellationToken cancellationToken)
        {
            var submarine = new Submarine(request.Name, request.Model, request.CommissionedDate, request.Status);

            await _submarineRepository.Create(submarine);
            return submarine;
        }
    }
}
