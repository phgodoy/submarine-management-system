﻿using AutoMapper;
using Sms.Application.Dtos;
using Sms.Application.Interfaces;
using MediatR;
using Sms.Application.Submarines.Commands;
using Sms.Application.Submarines.Queries;

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
            var createCommand = new CreateSubmarineCommand(
                submarineDto.Name,
                submarineDto.Model,
                submarineDto.CreationDate,
                submarineDto.SubmarineStatusDto.Id
            );

            var result = await _mediator.Send(createCommand);
            return _mapper.Map<SubmarineDto>(result);
        }

        public async Task<bool> DisableSubmarine(int id)
        {
            var disableCommand = new UpdateSubmarineStatusCommand(id);
            return await _mediator.Send(disableCommand);
        }

        public async Task<bool> EnableSubmarine(int id)
        {
            var enableCommand = new UpdateSubmarineStatusCommand(id);
            return await _mediator.Send(enableCommand);
        }

        public async Task<SubmarineDto> GetSubmarineById(int id)
        {
            var query = new GetSubmarineByIdQuery(id);
            var result = await _mediator.Send(query);
            return _mapper.Map<SubmarineDto>(result);
        }

        public async Task<IEnumerable<SubmarineDto>> GetSubmarines()
        {
            var query = new GetSubmarinesQuery();
            var result = await _mediator.Send(query);
            return _mapper.Map<IEnumerable<SubmarineDto>>(result);
        }

        public async Task<bool> UpdateSubmarine(SubmarineDto submarineDto)
        {
            var updateCommand = new UpdateSubmarineCommand(
                submarineDto.Id,
                submarineDto.Name,
                submarineDto.Model,
                submarineDto.CreationDate,
                submarineDto.SubmarineStatusDto.Id
            );

            return await _mediator.Send(updateCommand);
        }
    }
}
