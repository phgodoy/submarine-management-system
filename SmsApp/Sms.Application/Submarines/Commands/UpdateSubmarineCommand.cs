using MediatR;
using Sms.Domain.Entities;
using Sms.Domain.Enums;

namespace Sms.Application.Submarines.Commands
{
    public class UpdateSubmarineCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public DateTime CommissionedDate { get; set; }
        public SubmarineStatusEnum SubmarineStatusId { get; set; }

        public UpdateSubmarineCommand(int id, string name, string model, DateTime commissionedDate, SubmarineStatusEnum submarineStatusId)
        {
            Id = id;
            Name = name;
            Model = model;
            CommissionedDate = commissionedDate;
            SubmarineStatusId = submarineStatusId;
        }
    }
}
