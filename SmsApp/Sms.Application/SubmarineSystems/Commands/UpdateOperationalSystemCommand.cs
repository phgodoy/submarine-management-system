using MediatR;

namespace Sms.Application.SubmarineSystems.Commands
{
    public class UpdateOperationalSystemCommand : IRequest<bool>
    {
        public int Id { get; }

        public UpdateOperationalSystemCommand(int id)
        {
            Id = id;
        }
    }
}
