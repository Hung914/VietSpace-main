using System.Threading;
using System.Threading.Tasks;
using Application.Repositories;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Addresses
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Address Address { get; set; }

        }
        
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                // RuleFor(x => x.Business).SetValidator(new BusinessValidator());
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IAddressesRepository _addressesRepository;

            public Handler(IAddressesRepository addressesRepository)
            {
                _addressesRepository = addressesRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _addressesRepository.UpdateAddressAsync(request.Address);
                return Unit.Value;
            }
        } 
    }
}