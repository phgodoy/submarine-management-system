using MediatR;
using Sms.Application.Dtos;

namespace Sms.Application.Submarines.Queries
{
    public class GetSubmarinesQuery : IRequest<IEnumerable<SubmarineDto>> { }
}
