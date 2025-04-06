using AutoMapper;
using MediatR;
using Sms.Application.Dtos;
using Sms.Application.SubmarineSystems.Queries;
using Sms.Domain.Interfaces;

namespace Sms.Application.SubmarineSystems.Handlers
{
    public class GetSubmarineSystemsQueryHandler : IRequestHandler<GetSubmarineSystemsQuery, IEnumerable<SubmarineSystemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISubmarineSystemRepository _submarineSystemRepository;

        public GetSubmarineSystemsQueryHandler(ISubmarineSystemRepository submarineSystemRepository, IMapper mapper)
        {
            _submarineSystemRepository = submarineSystemRepository ?? throw new ArgumentNullException(nameof(submarineSystemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SubmarineSystemDto>> Handle(GetSubmarineSystemsQuery request, CancellationToken cancellationToken)
        {
            var submarineSystems = await _submarineSystemRepository.GetSubmarineSystems();

            if (submarineSystems == null || !submarineSystems.Any())
            {
                throw new ApplicationException("No submarine systems found.");
            }

            return _mapper.Map<IEnumerable<SubmarineSystemDto>>(submarineSystems);
        }
    }
}
