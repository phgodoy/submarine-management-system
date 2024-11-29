using MediatR;

namespace Sms.Application.SubmarineSystems.Commands
{
    public class EnableSubmarineSystemCommand : IRequest<bool>
    {
        public int Id { get; }

        public EnableSubmarineSystemCommand(int id)
        {
            Id = id;
        }
    }
}
