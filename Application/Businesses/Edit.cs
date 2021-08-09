using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Repositories;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Businesses
{
    public class Edit
    {
        public class Command : IRequest
        {
            public BusinessDto Business { get; set; }

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
                await _businessesRepository.UpdateBusinessAsync(request.Business);
                return Unit.Value;
            }
        } 
    }
}