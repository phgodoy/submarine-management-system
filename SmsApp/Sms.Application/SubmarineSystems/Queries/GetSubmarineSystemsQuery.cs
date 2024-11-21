using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.SubmarineSystems.Queries
{
    public class GetSubmarineSystemsQuery : IRequest<IEnumerable<SubmarineSystem>>
    {
    }
}
