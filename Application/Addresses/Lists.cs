using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Addresses
{
    public class Lists
    {

        public List<AddressDto> Addresses {get; set;}
        public class Query : IRequest<Result<List<AddressDto>>> { }
        public class Handler : IRequestHandler<Query, Result<List<AddressDto>>>
        {
            private readonly IAddressesRepository _addressesRepository;
            private readonly IMapper _mapper;

            public Handler(IAddressesRepository addressesRepository, IMapper mapper)
            {
                _addressesRepository = addressesRepository;
                _mapper = mapper;
            }
            public async Task<Result<List<AddressDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var addresses = await _addressesRepository.GetAddressesAsync();
                var results =  _mapper.Map<List<AddressDto>>(addresses);
                return Result<List<AddressDto>>.Success(results);
            }
        } 
    }
}