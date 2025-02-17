//using MediatR;
//using Sms.Application.Submarines.Commands;
//using Sms.Domain.Interfaces;


//namespace Sms.Application.Submarines.Handlers
//{
//    public class DisableSubmarineCommandHandler : IRequestHandler<DisableSubmarineCommand, bool>
//    {
//        private readonly ISubmarineRepository _submarineRepository;

//        public DisableSubmarineCommandHandler(ISubmarineRepository submarineRepository)
//        {
//            _submarineRepository = submarineRepository;
//        }

//        public async Task<bool> Handle(DisableSubmarineCommand request, CancellationToken cancellationToken)
//        {
//            var submarine = await _submarineRepository.GetByIdAsync(request.Id);
//            if (submarine == null) return false;

//            submarine.DisableSubmarine(request.Id);
//            await _submarineRepository.UpdateAsync(submarine);
//            return true;
//        }
//    }
//}
