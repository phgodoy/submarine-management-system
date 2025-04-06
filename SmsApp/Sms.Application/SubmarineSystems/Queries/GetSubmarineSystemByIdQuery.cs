using MediatR;
using Sms.Application.Dtos;

namespace Sms.Application.SubmarineSystems.Queries
{
    public class GetSubmarineSystemByIdQuery : IRequest<SubmarineSystemDto>
    {
        public int Id { get; set; }

        public GetSubmarineSystemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
