using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Repositories;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Addresses
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }

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
                await _addressesRepository.DeleteAddressAsync(request.Id);
                return Unit.Value;
            }
        } 
    }
}