using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Photos;
using Application.Repositories;
using Domain;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Application.UnitTests
{
    public class PhotosTests
    {
         private readonly Mock<IBusinessesRepository> _bussinessRepositoryStub = new();
         private readonly Mock<IPhotoAccessor> _photoAccessor = new();
        [Fact]
        //public void UnitOfWork_StateUnderTest_ExpectedBehavior()
        public async Task AddPhotoToBusinessAsync_Successful_ReturnSuccessResult()
        {
            //Arrange
            var publicId = "publicId";
            var url = "testurl.com";
            var photoUploadResult = new PhotoUploadResult {PublicId = publicId, Url = url};
            var photo = new Photo {Id = publicId, Url = url};
            
            _photoAccessor.Setup(p => p.AddPhotoAsync(It.IsAny<IFormFile>())).ReturnsAsync(photoUploadResult);
            _bussinessRepositoryStub.Setup(b => b.AddPhotoAsync(It.IsAny<Guid>(),It.IsAny<Photo>()))
                .ReturnsAsync(true);
            var command = new Add.Command();
            var handler = new Add.Handler(_bussinessRepositoryStub.Object, _photoAccessor.Object);
            
            //Act
            var result = await handler.Handle(command, It.IsAny<CancellationToken>());
                
            //Assert
            result.Value.Should().BeEquivalentTo(photo);
        }
        
        
        [Fact]
        //public void UnitOfWork_StateUnderTest_ExpectedBehavior()
        public async Task DeletePhotoAsync_Successful_ReturnSuccessResult()
        {
            //Arrange
            _photoAccessor.Setup(p => p.DeletePhotoAsync(It.IsAny<string>()))
                .ReturnsAsync("ok");
            
            _bussinessRepositoryStub.Setup(b => b.DeletePhotoAsync(It.IsAny<string>()))
                .ReturnsAsync(true);

            var request = new Delete.Command {Id = "abcdef"};
            var handler = new Delete.Command.Handler(_bussinessRepositoryStub.Object, _photoAccessor.Object);
            
            //Act
            var result = await handler.Handle(request, It.IsAny<CancellationToken>());
                
            //Assert
            result.Value.Should().Be(Unit.Value);
        }


    }
}