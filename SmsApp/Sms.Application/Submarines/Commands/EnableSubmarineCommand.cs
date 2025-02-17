using MediatR;

namespace Sms.Application.Submarines.Commands
{
        public class EnableSubmarineCommand : IRequest<bool>
        {
            public int Id { get; }

            public EnableSubmarineCommand(int id)
            {
                Id = id;
            }
        }
}
