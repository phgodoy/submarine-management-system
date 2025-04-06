using AutoMapper;
using MediatR;
using Sms.Application.Dtos;
using Sms.Application.SubmarineSystems.Queries;
using Sms.Domain.Interfaces;

namespace Sms.Application.SubmarineSystems.Handlers
{
    public class GetSubmarineSystemByIdQueryHandler : IRequestHandler<GetSubmarineSystemByIdQuery, SubmarineSystemDto>
    {
        private readonly IMapper _mapper;
        private readonly ISubmarineSystemRepository _submarineSystemRepository;

        public GetSubmarineSystemByIdQueryHandler(ISubmarineSystemRepository submarineSystemRepository, IMapper mapper)
        {
            _submarineSystemRepository = submarineSystemRepository ?? throw new ArgumentNullException(nameof(submarineSystemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SubmarineSystemDto> Handle(GetSubmarineSystemByIdQuery request, CancellationToken cancellationToken)
        {
            var submarineSystem = await _submarineSystemRepository.GetSubmarineSystemsById(request.Id);

            if (submarineSystem == null)
            {
                throw new KeyNotFoundException($"Submarine system with ID {request.Id} not found.");
            }

            return _mapper.Map<SubmarineSystemDto>(submarineSystem);
        }
    }
}
