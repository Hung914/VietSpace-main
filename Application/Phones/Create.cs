using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Phones
{
    public class Create
    {
        public class Command : IRequest
        {
            public Phone Phone { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {

            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IPhonesRepository _phonesRepository;
            public Handler(IPhonesRepository phonesRepository)
            {
                _phonesRepository = phonesRepository;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _phonesRepository.CreatePhoneAsync(request.Phone);
                return Unit.Value;
            }
        }
    }
}