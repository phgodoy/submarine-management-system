using AutoMapper;
using Sms.Application.DTOs;
using Sms.Application.Interfaces;
using MediatR;
using Sms.Application.SubmarineSystems.Queries;

namespace Sms.Application.Services
{
    public class SubmarineSystemService : ISubmarineSystem
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

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
    }
}
