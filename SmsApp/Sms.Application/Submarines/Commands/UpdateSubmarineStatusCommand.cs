using MediatR;

namespace Sms.Application.Submarines.Commands
{
    public class UpdateSubmarineStatusCommand : IRequest<bool>
    {
        public int Id { get; }

        public UpdateSubmarineStatusCommand(int id)
        {
            Id = id;
        }
    }
}
