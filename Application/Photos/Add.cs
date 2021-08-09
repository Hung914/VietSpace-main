using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Repositories;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Photos
{
    public class Add 
    {
        public class Command : IRequest<Result<Photo>>
        {
            public Guid BusinessId { get; set; }
            public IFormFile File { get; set; }
        }


        public class Handler : IRequestHandler<Command, Result<Photo>>
        {
            private readonly IBusinessesRepository _businessesRepository;
            private readonly IPhotoAccessor _photoAccessor;

            public Handler(IBusinessesRepository businessesRepository,IPhotoAccessor photoAccessor)
            {
                _businessesRepository = businessesRepository;
                _photoAccessor = photoAccessor;
            }
            
            public async Task<Result<Photo>> Handle(Command request, CancellationToken cancellationToken)
            {
                var photoUploadResult = await _photoAccessor.AddPhotoAsync(request.File);

                var photo = new Photo
                {
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId
                };

                var result = await _businessesRepository.AddPhotoAsync(request.BusinessId, photo);

                if (result) return Result<Photo>.Success(photo);

                return Result<Photo>.Failure("Problem adding photo");
            }
        }
    }
    
}