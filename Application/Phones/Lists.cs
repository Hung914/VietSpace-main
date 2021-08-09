using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Phones
{
    public class Lists
    {
        public List<PhoneDto> Phones { get; set; }

        public class Query : IRequest<List<PhoneDto>> { }
        public class Handler : IRequestHandler<Query, List<PhoneDto>>
        {
            private readonly IPhonesRepository _phonesRepository;
            private readonly IMapper _mapper;

            public Handler(IPhonesRepository phonesRepository, IMapper mapper)
            {
                this._mapper = mapper;
                this._phonesRepository = phonesRepository;

            }

            public async Task<List<PhoneDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var phones = await _phonesRepository.GetPhonesAsync();
                var results = _mapper.Map<List<PhoneDto>, List<PhoneDto>>(phones);
                return results;
            }
        }
    }
}