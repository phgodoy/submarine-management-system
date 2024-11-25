using MediatR;
using Sms.Application.SubmarineSystems.Queries;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;

namespace Sms.Application.SubmarineSystems.Handlers
{
    public class GetSubmarineSystemByIdQueryHandler : IRequestHandler<GetSubmarineSystemByIdQuery, SubmarineSystem>
    {
        private readonly ISubmarineSystemRepository _submarineSystemRepository;

        public GetSubmarineSystemByIdQueryHandler(ISubmarineSystemRepository submarineSystemRepository)
        {
            _submarineSystemRepository = submarineSystemRepository ?? throw new ArgumentNullException(nameof(submarineSystemRepository));
        }

        public async Task<SubmarineSystem> Handle(GetSubmarineSystemByIdQuery request, CancellationToken cancellationToken)
        {
            var submarineSystem = await _submarineSystemRepository.GetSubmarineSystemById(request.Id);

            if (submarineSystem == null)
            {
                throw new KeyNotFoundException($"Submarine system with ID {request.Id} not found.");
            }

            return submarineSystem;
        }
    }
}
