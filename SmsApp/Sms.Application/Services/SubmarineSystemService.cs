using AutoMapper;
using Sms.Application.DTOs;
using Sms.Application.Interfaces;
using MediatR;
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
    }
}
