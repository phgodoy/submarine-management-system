using AutoMapper;
using MediatR;
using Sms.Application.Commands;
using Sms.Application.DTOs;
using Sms.Application.Interfaces;
using Sms.Application.Submarines.Commands;

namespace Sms.Application.Services
{
    public class SubmarineService : ISubmarineService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SubmarineService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SubmarineDto> CreateSubmarine(SubmarineDto submarineDto)
        {
            if (submarineDto == null)
            {
                throw new ArgumentNullException(nameof(submarineDto), "Submarine data cannot be null");
            }

            var createCommand = new CreateSubmarineCommand(
                submarineDto.Name,
                submarineDto.Model,
                submarineDto.CommissionedDate,
                submarineDto.Status
            );

            var result = await _mediator.Send(createCommand);

            return _mapper.Map<SubmarineDto>(result);
        }
    }
}
