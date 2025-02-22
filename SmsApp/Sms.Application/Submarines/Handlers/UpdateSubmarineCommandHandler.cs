using MediatR;
using Sms.Application.Submarines.Commands;
using Sms.Domain.Interfaces;

namespace Sms.Application.Submarines.Handlers
{
    public class UpdateSubmarineCommandHandler : IRequestHandler<UpdateSubmarineCommand, bool>
    {
        private readonly ISubmarineRepository _submarineRepository;

        public UpdateSubmarineCommandHandler(ISubmarineRepository submarineRepository)
        {
            _submarineRepository = submarineRepository;
        }

        public async Task<bool> Handle(UpdateSubmarineCommand request, CancellationToken cancellationToken)
        {
            var submarine = await _submarineRepository.GetSubmarineById(request.Id);
            if (submarine == null) return false;

            submarine.Update(request.Name, request.Model, request.CommissionedDate, request.SubmarineStatusId);
            return await _submarineRepository.Update(submarine);
        }
    }
}
