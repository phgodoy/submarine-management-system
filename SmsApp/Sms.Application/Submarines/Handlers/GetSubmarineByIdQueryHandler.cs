using AutoMapper;
using MediatR;
using Sms.Application.Dtos;
using Sms.Application.Submarines.Queries;
using Sms.Domain.Interfaces;

namespace Sms.Application.Submarines.Handlers
{
    public class GetSubmarineByIdQueryHandler : IRequestHandler<GetSubmarineByIdQuery, SubmarineDto>
    {
        private readonly IMapper _mapper;
        private readonly ISubmarineRepository _submarineRepository;

        public GetSubmarineByIdQueryHandler(ISubmarineRepository submarineRepository, IMapper mapper)
        {
            _submarineRepository = submarineRepository ?? throw new ArgumentNullException(nameof(submarineRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SubmarineDto> Handle(GetSubmarineByIdQuery request, CancellationToken cancellationToken)
        {
            var submarine = await _submarineRepository.GetSubmarineById(request.Id);

            if (submarine == null)
            {
                throw new KeyNotFoundException($"Submarine with ID {request.Id} not found.");
            }

            return _mapper.Map<SubmarineDto>(submarine);
        }
    }
}
