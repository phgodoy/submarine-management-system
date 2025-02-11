using MediatR;
using Sms.Domain.Entities;

namespace Sms.Application.Submarines.Commands
{
    public class CreateSubmarineCommand : IRequest<Submarine>
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public DateTime CommissionedDate { get; set; }
        public int Status { get; set; }

        public CreateSubmarineCommand(string name, string model, DateTime commissionedDate, int status)
        {
            Name = name;
            Model = model;
            CommissionedDate = commissionedDate;
            Status = status;
        }
    }
}
