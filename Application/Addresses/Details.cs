using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Repositories;
using Domain;
using MediatR;
using Persistence;

namespace Application.Addresses
{
    public class Details
    {

        public class Command : IRequest<AddressDto> { 
            public Guid Id {get; set;}
        }

        public class Handler : IRequestHandler<Command, AddressDto>
        {

            private readonly IAddressesRepository _addressesRepository;
            public Handler(IAddressesRepository addressesRepository)
            {
                _addressesRepository = addressesRepository;
            }
            public async Task<AddressDto> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _addressesRepository.GetAddressAsync(request.Id);
            }
        }
    }
}