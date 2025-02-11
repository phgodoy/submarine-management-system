using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.Submarines.Queries
{
    public class GetSubmarineByIdQuery : IRequest<Submarine>
    {
        public int Id { get; }

        public GetSubmarineByIdQuery(int id)
        {
            Id = id;
        }
    }
}
