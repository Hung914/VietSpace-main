using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using MediatR;

namespace Application.Phones
{
    public class Details
    {
        public class Command : IRequest<PhoneDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, PhoneDto>
        {
            private readonly IPhonesRepository _phonesRepository;
            public Handler(IPhonesRepository phonesRepository)
            {
                _phonesRepository = phonesRepository;

            }

            public async Task<PhoneDto> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _phonesRepository.GetPhoneAsync(request.Id);
            }
        }
    }
}