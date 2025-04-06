using MediatR;
using Sms.Application.Dtos;

namespace Sms.Application.SubmarineSystems.Queries
{
    public class GetSubmarineSystemsQuery : IRequest<IEnumerable<SubmarineSystemDto>> { }
}
