using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Controllers;
using Application.Businesses;
using Application.Core;
using Application.Photos;
using Domain;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Delete = Application.Photos.Delete;

namespace API.UnitTests
{
    public class PhotosControllerTests
    {
        private readonly Mock<IMediator> _mediatorStub = new();

        [Fact]
        //public void UnitOfWork_StateUnderTest_ExpectedBehavior()
        public async Task AddPhoto_ToExistingBusiness_ReturnsPhoto()
        {
            //Arrange
            var url = "testiamge.com";
            var photo = new Photo{Url = url};
            _mediatorStub.Setup(m => m.Send(It.IsAny<Add.Command>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result<Photo>.Success(photo));
            var controller = new PhotosController(_mediatorStub.Object);

            var addPhotoCommand = new Add.Command();
            //Act
            var result = (OkObjectResult) await controller.Add(addPhotoCommand);

            //Assert
            result.Value
                .Should().BeEquivalentTo(photo);
        }
        
        [Fact]
        //public void UnitOfWork_StateUnderTest_ExpectedBehavior()
        public async Task DeletePhoto_OfExistingBusiness_Returns200()
        {
            //Arrange
            var photoId = "kmrgecvjc6rbmd7iu9kj";
     
            _mediatorStub.Setup(m => m.Send(It.IsAny<Delete.Command>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result<Unit>.Success(Unit.Value));
            var controller = new PhotosController(_mediatorStub.Object);

            //Act
            var result = (OkObjectResult) await controller.Delete(photoId);

            //Assert
            result.StatusCode
                .Should().Be(200);
        }
    }
}