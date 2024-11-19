using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.SubmarineSystems.Queries
{
    internal class GetSubmarineSystemsByIdQuery : IRequest<SubmarineSystem>
    {
        public int Id { get; set; }

        public GetSubmarineSystemsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
