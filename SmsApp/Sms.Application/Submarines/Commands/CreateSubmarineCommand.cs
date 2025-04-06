using MediatR;
using Sms.Domain.Entities;
using Sms.Domain.Enums;

namespace Sms.Application.Submarines.Commands
{
    public class CreateSubmarineCommand : IRequest<Submarine>
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public DateTime CreationDate { get; set; }
        public SubmarineStatusEnum SubmarineStatusId { get; set; }

        public CreateSubmarineCommand(string name, string model, DateTime creationDate, SubmarineStatusEnum submarineStatusId)
        {
            Name = name;
            Model = model;
            CreationDate = creationDate;
            SubmarineStatusId = submarineStatusId;
        }
    }
}