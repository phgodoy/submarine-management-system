using MediatR;

namespace Sms.Application.Submarines.Commands
{
    public class DisableSubmarineCommand : IRequest<bool>
    {
        public int Id { get; }

        public DisableSubmarineCommand(int id)
        {
            Id = id;
        }
    }
}
