using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Businesses
{
    public class Create
    {
        public class Command : IRequest
        {
            public Business Business { get; set; }

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
            private readonly IBusinessesRepository _businessesRepository;

            public Handler(IBusinessesRepository businessesRepository)
            {
                _businessesRepository = businessesRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _businessesRepository.CreateBusinessAsync(request.Business);
                return Unit.Value;
            }
        } 


    }

}