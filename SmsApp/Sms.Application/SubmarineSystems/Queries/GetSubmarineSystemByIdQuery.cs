using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.SubmarineSystems.Queries
{
    public class GetSubmarineSystemByIdQuery : IRequest<SubmarineSystem>
    {
        public int Id { get; set; }

        public GetSubmarineSystemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
