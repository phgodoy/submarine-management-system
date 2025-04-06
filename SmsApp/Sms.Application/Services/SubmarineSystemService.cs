using AutoMapper;
using MediatR;
using Sms.Application.Dtos;
using Sms.Application.Interfaces;
using Sms.Application.SubmarineSystems.Commands;
using Sms.Application.SubmarineSystems.Queries;

namespace Sms.Application.Services
{
    public class SubmarineSystemService : ISubmarineSystemService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SubmarineSystemService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SubmarineSystemDto> CreateSubmarineSystem(SubmarineSystemDto submarineSystemDto)
        {
            var command = new CreateSubmarineSystemCommand(
                submarineSystemDto.SubmarineId,
                submarineSystemDto.Name,
                submarineSystemDto.Type,
                submarineSystemDto.SystemStatusId,
                submarineSystemDto.LastMaintenanceDate
            );

            var result = await _mediator.Send(command);
            return _mapper.Map<SubmarineSystemDto>(result);
        }

        public async Task<bool> DisableSubmarineSystem(int id)
        {
            var command = new UpdateOperationalSystemCommand(id);
            return await _mediator.Send(command);
        }

        public async Task<bool> EnableSubmarineSystem(int id)
        {
            var command = new UpdateOperationalSystemCommand(id);
            return await _mediator.Send(command);
        }

        public async Task<IEnumerable<SubmarineSystemDto>> GetSubmarineSystems()
        {
            var query = new GetSubmarineSystemsQuery();
            var result = await _mediator.Send(query);
            return _mapper.Map<IEnumerable<SubmarineSystemDto>>(result);
        }

        public async Task<SubmarineSystemDto> GetSubmarineSystemsById(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var query = new GetSubmarineSystemByIdQuery(id.Value);
            var result = await _mediator.Send(query);
            return _mapper.Map<SubmarineSystemDto>(result);
        }

        public async Task<bool> UpdateSubmarineSystem(SubmarineSystemDto submarineSystemDto)
        {
            var command = new UpdateSubmarineSystemCommand(
                submarineSystemDto.Id,
                submarineSystemDto.SubmarineId,
                submarineSystemDto.Name,
                submarineSystemDto.Type,
                submarineSystemDto.SystemStatusId,
                submarineSystemDto.LastMaintenanceDate
            );

            return await _mediator.Send(command);
        }
    }
}
