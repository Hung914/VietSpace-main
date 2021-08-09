using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Businesses;
using Application.Dtos;
using Application.Core;
using Application.Repositories;
using AutoMapper;
using Domain;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

namespace Application.UnitTests
{
    public class BusinessesListTests
    {
        private readonly Mock<IBusinessesRepository> _bussinessRepositoryStub = new();
        [Fact]
        //public void UnitOfWork_StateUnderTest_ExpectedBehavior()
        public async Task ListBusinessesAsync_WithExistingBusinesses_ReturnsListOfBusinesses()
        {
            //Arrange
            var count = 5;
            _bussinessRepositoryStub.Setup(x => x.GetBusinessesAsync())
                .ReturnsAsync(CreateRandomBusinessList(count));

            var mapperMock = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = mapperMock.CreateMapper();
            
            var listQuery = new List.Query();
            var listHandler = new List.Handler(_bussinessRepositoryStub.Object, mapper);

            //Act
            var result = await listHandler.Handle(listQuery, It.IsAny<CancellationToken>());
            
            //Assert
            result.Value.Should().BeOfType<List<BusinessDto>>()
                .And.HaveCount(count);
        } 
        
        
        
        private List<BusinessDto> CreateRandomBusinessList(int count)
        {
            var businesses = new List<BusinessDto>();
            for (int i = 0; i < count; i++)
            {
                businesses.Add(CreateRandomBusiness());
            }

            return businesses;
        }

        private BusinessDto CreateRandomBusiness()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
            };

        }
    }
}