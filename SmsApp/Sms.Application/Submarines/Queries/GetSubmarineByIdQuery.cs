using MediatR;
using Sms.Application.Dtos;

namespace Sms.Application.Submarines.Queries
{
    public class GetSubmarineByIdQuery : IRequest<SubmarineDto>
    {
        public int Id { get; set; }
        public GetSubmarineByIdQuery(int id)
        {
            Id = id;
        }
    }
}
