using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Repositories;
using Domain;
using MediatR;
using Persistence;

namespace Application.Businesses
{
    public class Details
    {

        public class Command : IRequest<BusinessDto> { 
            public Guid Id {get; set;}
        }

        public class Handler : IRequestHandler<Command, BusinessDto>
        {

            private readonly IBusinessesRepository _businessesRepository;
            public Handler(IBusinessesRepository businessesRepository)
            {
                _businessesRepository = businessesRepository;
            }
            public async Task<BusinessDto> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _businessesRepository.GetBusinessAsync(request.Id);
            }
        }
    }
}