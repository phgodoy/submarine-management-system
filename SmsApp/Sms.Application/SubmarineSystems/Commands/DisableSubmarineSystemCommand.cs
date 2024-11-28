using MediatR;

namespace Sms.Application.SubmarineSystems.Commands
{
    public class DisableSubmarineSystemCommand : IRequest<bool>
    {
        public int Id { get; }

        public DisableSubmarineSystemCommand(int id)
        {
            Id = id;
        }
    }
}
