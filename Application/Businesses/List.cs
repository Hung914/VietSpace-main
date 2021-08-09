using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Businesses
{
    public class List
    {

        public List<BusinessDto> Businesses {get; set;}
        public class Query : IRequest<Result<List<BusinessDto>>> { }
        public class Handler : IRequestHandler<Query, Result<List<BusinessDto>>>
        {
            private readonly IBusinessesRepository _businessesRepository;
            private readonly IMapper _mapper;

            public Handler(IBusinessesRepository businessesRepository, IMapper mapper)
            {
                _businessesRepository = businessesRepository;
                _mapper = mapper;
            }
            public async Task<Result<List<BusinessDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var businesses = await _businessesRepository.GetBusinessesAsync();
                var results =  _mapper.Map<List<BusinessDto>>(businesses);
                return Result<List<BusinessDto>>.Success(results);
            }
        } 
    }
}