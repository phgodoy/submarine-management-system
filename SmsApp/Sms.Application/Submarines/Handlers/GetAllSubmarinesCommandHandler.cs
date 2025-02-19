using AutoMapper;
using MediatR;
using Sms.Application.Dtos;
using Sms.Application.Submarines.Queries;
using Sms.Domain.Interfaces;

namespace Sms.Application.Submarines.Handlers
{
    public class GetSubmarinesQueryHandler : IRequestHandler<GetSubmarinesQuery, IEnumerable<SubmarineDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISubmarineRepository _submarineRepository;

        public GetSubmarinesQueryHandler(ISubmarineRepository submarineRepository, IMapper mapper)
        {
            _submarineRepository = submarineRepository ?? throw new ArgumentNullException(nameof(submarineRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SubmarineDto>> Handle(GetSubmarinesQuery request, CancellationToken cancellationToken)
        {
            var submarines = await _submarineRepository.GetSubmarines();

            if (submarines == null || !submarines.Any())
            {
                throw new ApplicationException("No submarines found.");
            }

            return _mapper.Map<IEnumerable<SubmarineDto>>(submarines);
        }
    }
}
