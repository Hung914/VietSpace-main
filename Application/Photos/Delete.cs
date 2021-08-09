using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Repositories;
using MediatR;

namespace Application.Photos
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
            
            public class Handler: IRequestHandler<Command, Result<Unit>>
            {
                private readonly IBusinessesRepository _businessesRepository;
                private readonly IPhotoAccessor _photoAccessor;

                public Handler(IBusinessesRepository businessesRepository, IPhotoAccessor photoAccessor)
                {
                    _businessesRepository = businessesRepository;
                    _photoAccessor = photoAccessor;
                }
                
                public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
                {
                    var result = await _photoAccessor.DeletePhotoAsync(request.Id);
                    
                    if (result is null) return Result<Unit>.Failure("Problem deleting photo from Cloudinary");
                    
                    var success = await _businessesRepository.DeletePhotoAsync(request.Id);
                    
                    if (success) return Result<Unit>.Success(Unit.Value);

                    return Result<Unit>.Failure("Problem deleting photo from API");
                }
            }
        }
    }
}