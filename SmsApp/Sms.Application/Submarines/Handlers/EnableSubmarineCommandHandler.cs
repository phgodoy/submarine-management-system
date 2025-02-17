//using MediatR;
//using Sms.Application.Submarines.Commands;
//using Sms.Domain.Interfaces;

//namespace Sms.Application.Submarines.Handlers
//{
//    public class EnableSubmarineCommandHandler : IRequestHandler<EnableSubmarineCommand, bool>
//    {
//        private readonly ISubmarineRepository _repository;

//        public EnableSubmarineCommandHandler(ISubmarineRepository repository)
//        {
//            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
//        }

//        public async Task<bool> Handle(EnableSubmarineCommand request, CancellationToken cancellationToken)
//        {
//            if (request == null)
//                throw new ArgumentNullException(nameof(request), "The request cannot be null.");

//            var submarine = await _repository.GetSubmarineById(request.Id);
//            if (submarine == null)
//                return false;

//            submarine.Enable();
//            await _repository.UpdateAsync(submarine);

//            return true;
//        }
//    }
//}
