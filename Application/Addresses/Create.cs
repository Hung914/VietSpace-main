using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Addresses
{
    public class Create
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
                await _addressesRepository.CreateAddressAsync(request.Address);
                return Unit.Value;
            }
        } 


    }

}