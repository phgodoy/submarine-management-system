using MediatR;
using Sms.Application.SubmarineSystems.Queries;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;

namespace Sms.Application.SubmarineSystems.Handlers
{
    public class GetSubmarineSystemsQueryHandler : IRequestHandler<GetSubmarineSystemsQuery, IEnumerable<SubmarineSystem>>
    {
        private readonly ISubmarineSystemRepository _submarineSystemRepository;

        public GetSubmarineSystemsQueryHandler(ISubmarineSystemRepository submarineSystemRepository)
        {
            _submarineSystemRepository = submarineSystemRepository ?? throw new ArgumentNullException(nameof(submarineSystemRepository));
        }

        public async Task<IEnumerable<SubmarineSystem>> Handle(GetSubmarineSystemsQuery request, CancellationToken cancellationToken)
        {
            var submarineSystems = await _submarineSystemRepository.GetSystems();

            if (submarineSystems == null || !submarineSystems.Any())
            {
                throw new ApplicationException("No submarine systems found");
            }

            return submarineSystems;
        }
    }
}
