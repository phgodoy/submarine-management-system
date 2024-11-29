using AutoMapper;
using Sms.Application.DTOs;
using Sms.Application.Interfaces;
using MediatR;
using Sms.Application.SubmarineSystems.Queries;
using Sms.Domain.Entities;
using Sms.Application.Commands;
using Sms.Application.SubmarineSystems.Commands;

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

        public async Task<IEnumerable<SubmarineSystemDTO>> GetSubmarineSystems()
        {
            var SubmarineSystemsQuery = new GetSubmarineSystemsQuery();

            if (SubmarineSystemsQuery == null)
            {
                throw new Exception($"Entity cloud not be loaded");
            }

            var result = await _mediator.Send(SubmarineSystemsQuery);

            return _mapper.Map<IEnumerable<SubmarineSystemDTO>>(result);
        }

        public async Task<SubmarineSystemDTO> GetSubmarineSystemById(int id)
        {
            var submarineSystemQuery = new GetSubmarineSystemByIdQuery(id);

            if (submarineSystemQuery == null)
            {
                throw new Exception($"Entity cloud not be loaded");
            }
            var result = await _mediator.Send(submarineSystemQuery);

            return _mapper.Map<SubmarineSystemDTO>(result);
        }

        public async Task<SubmarineSystemDTO> CreateSubmarineSystem(SubmarineSystemDTO submarineSystemDto)
        {
            if (submarineSystemDto == null)
            {
                throw new ArgumentNullException(nameof(submarineSystemDto), "Submarine system data cannot be null");
            }

            var createCommand = new CreateSubmarineSystemCommand(
                submarineSystemDto.Name,
                submarineSystemDto.Type,
                submarineSystemDto.OperationalStatus,
                submarineSystemDto.LastMaintenanceDate
            );

            var result = await _mediator.Send(createCommand);

            return _mapper.Map<SubmarineSystemDTO>(result);
        }

        public async Task<SubmarineSystemDTO> UpdateSubmarineSystem(int id, SubmarineSystemDTO submarineSystem)
        {
            if (submarineSystem == null)
                throw new ArgumentNullException(nameof(submarineSystem), "Submarine system data cannot be null.");

            // Create the command
            var updateCommand = new UpdateSubmarineSystemCommand(
                submarineSystem.Id = id,
                submarineSystem.Name,
                submarineSystem.Type,
                submarineSystem.OperationalStatus,
                submarineSystem.LastMaintenanceDate
            );

            // Send the command to the handler
            var updatedSubmarineSystem = await _mediator.Send(updateCommand);

            if (updatedSubmarineSystem == null)
                return null; // Return null if the submarine system was not found or could not be updated

            // Map the updated entity to a DTO and return it
            return _mapper.Map<SubmarineSystemDTO>(updatedSubmarineSystem);
        }

        public async Task<bool> DisableSubmarineSystem(int id)
        {
            if (id <= 0)
                throw new ArgumentException("The ID must be greater than zero.", nameof(id));

            var disableCommand = new DisableSubmarineSystemCommand(id);

            var result = await _mediator.Send(disableCommand);

            return result;
        }

        public async Task<bool> EnableSubmarineSystem(int id)
        {
            if (id <= 0)
                throw new ArgumentException("The ID must be greater than zero.", nameof(id));

            var disableCommand = new EnableSubmarineSystemCommand(id);

            var result = await _mediator.Send(disableCommand);

            return result;
        }
    }
}
