using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Phones
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }

        }
    

        public class Handler : IRequestHandler<Command>
        {
            private readonly IPhonesRepository _businessesRepository;

            public Handler(IPhonesRepository businessesRepository)
            {
                _businessesRepository = businessesRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _businessesRepository.DeletePhoneAsync(request.Id);
                return Unit.Value;
            }
        }       
    }
}