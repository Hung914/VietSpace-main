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

namespace Application.Businesses
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }

        }
    

        public class Handler : IRequestHandler<Command>
        {
            private readonly IBusinessesRepository _businessesRepository;

            public Handler(IBusinessesRepository businessesRepository)
            {
                _businessesRepository = businessesRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _businessesRepository.DeleteBusinessAsync(request.Id);
                return Unit.Value;
            }
        } 
    }
}