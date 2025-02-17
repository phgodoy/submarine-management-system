using MediatR;
using Sms.Application.Submarines.Commands;
using Sms.Domain.Interfaces;

namespace Sms.Application.Submarines.Handlers
{
    public class CreateSubmarineCommandHandler : IRequestHandler<CreateSubmarineCommand, Submarine>
    {
        private readonly ISubmarineRepository _repository;

        public CreateSubmarineCommandHandler(ISubmarineRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Submarine> Handle(CreateSubmarineCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "The request cannot be null.");

            var submarine = new Submarine(
                request.Name,
                request.Model,
                request.CreationDate,
                request.SubmarineStatusId
            );

            return await _repository.Create(submarine);
        }
    }
}
