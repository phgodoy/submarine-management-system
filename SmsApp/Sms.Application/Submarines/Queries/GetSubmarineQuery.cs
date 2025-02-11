using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.Submarines.Queries
{
    public class GetSubmarineQuery : IRequest<IEnumerable<Submarine>>
    {
    }
}
