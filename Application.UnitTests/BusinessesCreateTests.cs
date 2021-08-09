using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Exceptions;
using Application.Businesses;
using Application.Dtos;
using Application.Repositories;
using AutoMapper;
using Domain;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

namespace Application.UnitTests
{
    public class BusinessesEditTests
    {
        private readonly Mock<IBusinessesRepository> _bussinessRepositoryStub = new();
        [Fact]
        //public void UnitOfWork_StateUnderTest_ExpectedBehavior()
        public async Task EditBusinessAsync_WithExistingBusiness_ReturnsUnit()
        {
            //Arrange
            var business = CreateRandomBusiness();
            
            var editCommand = new Edit.Command{Business = business};
            var editHandler = new Edit.Handler(_bussinessRepositoryStub.Object);

            //Act
            var result = await editHandler.Handle(editCommand, It.IsAny<CancellationToken>());
            
            //Assert
            result.Should().BeOfType<Unit>();
        }
        
        [Fact]
        //public void UnitOfWork_StateUnderTest_ExpectedBehavior()
        public async Task EditBusinessAsync_WithNonExistingBusiness_ThrowNotFoundException()
        {
            //Arrange
            var business = CreateRandomBusiness();
            _bussinessRepositoryStub.Setup(x => x.UpdateBusinessAsync(It.IsAny<Business>()))
                .ThrowsAsync(new NotFoundException("business not exist"));
            
            var editCommand = new Edit.Command{Business = business};
            var editHandler = new Edit.Handler(_bussinessRepositoryStub.Object);

            //Act
            Func<Task> action = async () => await editHandler.Handle(editCommand, It.IsAny<CancellationToken>());
                
            //Assert
            action.Should().Throw<NotFoundException>();
        }
        
        
        private Business CreateRandomBusiness()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
            };
        }
    }
}