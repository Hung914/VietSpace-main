using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Controllers;
using Application.Businesses;
using Application.Core;
using Application.Dtos;
using Application.Repositories;
using Domain;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace API.UnitTests
{
    public class BusinessesControllerTests
    {
        private readonly Mock<IMediator> _mediatorStub = new();

        [Fact]
        //public void UnitOfWork_StateUnderTest_ExpectedBehavior()
        public async Task GetBusinessesAsync_WithExistingBusinesses_ReturnsListOfBusinesses()
        {
            //Arrange
            var count = 3;
            var businesses = CreateRandomBusinessList(count);
            //_mapper
            _mediatorStub.Setup(m => m.Send(It.IsAny<List.Query>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result<List<BusinessDto>>.Success(businesses));
            var controller = new BusinessesController(_mediatorStub.Object);

            //Act
            var response = await controller.GetBusinesses();
            var result = response.Result as OkObjectResult;
            // var result =(OkObjectResult) await controller.GetBusinesses();

            //Assert
            result.Value
                .Should().BeOfType<List<BusinessDto>>();
            //.And.HaveCount(3)
            //.And.OnlyContain(x => x.Id != null);
        }

        [Fact]
        public async Task GetBusinessAsync_WithNonExistingBusiness_ReturnsNotFound()
        {
            //Arrange
            _mediatorStub.Setup(m => m.Send(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Business)null);
            var controller = new BusinessesController(_mediatorStub.Object);

            //Act
            var result = await controller.GetBusiness(Guid.NewGuid());

            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();

        }

        [Fact]
        public async Task GetBusinessAsync_WithExistingBusiness_ReturnBussiness()
        {
            //Arrange
            var expectedBusiness = CreateRandomBusiness();
            _mediatorStub.Setup(m => m.Send(It.IsAny<Details.Command>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedBusiness);          
            var controller = new BusinessesController(_mediatorStub.Object);

            //Act
            var response = await controller.GetBusiness(expectedBusiness.Id);
            var result = response.Result as OkObjectResult;

            //Assert
            result.Value.Should().BeEquivalentTo(expectedBusiness,
                options => options.ComparingByMembers<Business>());
        }

        [Fact]
        public async Task CreateBusinessAsync_WithABusinessAdded_ReturnOk()
        {
            // //Arrange
            // var business = CreateRandomBusiness();
            // var id = business.Id;
            // _mediatorStub.Setup(m => m.Send(It.IsAny<Edit.Command>(), It.IsAny<CancellationToken>()))
            //     .ReturnsAsync(Unit.Value);
            // var controller = new BusinessesController(_mediatorStub.Object);

            // //Act
            // var result = await controller.EditBusiness(id, business);

            // //Assert
            // result.Should().BeOfType<OkObjectResult>();

            //Arrange
            var businessToCreate = new Business
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                CreatedDate = DateTimeOffset.UtcNow,
                UpdatedDate = DateTimeOffset.UtcNow,
                CategoryId = 1,
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Description2 = Guid.NewGuid().ToString(),
                Description3 = Guid.NewGuid().ToString(),
                Emails = new List<Email>(),
                Phones = new List<Phone>(),
                Addresses = new List<Address>(),
                Website = Guid.NewGuid().ToString(),
                Abn = Guid.NewGuid().ToString()
            };
            _mediatorStub.Setup(m => m.Send(It.IsAny<Edit.Command>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value);
            var controller = new BusinessesController(_mediatorStub.Object);

            // Act 
            var result = await controller.CreateBusiness(businessToCreate);

            //Asssert 
            var createdBusiness = result as Business;
            businessToCreate.Should().BeEquivalentTo(
                createdBusiness,
                options => options.ComparingByMembers<OkObjectResult>().ExcludingMissingMembers()
            );
            createdBusiness.Id.Should().NotBeEmpty();
            createdBusiness.CreatedDate.Should().BeCloseTo(DateTimeOffset.UtcNow, 1000);



        }

        [Fact]
        public async Task EditBusinessAsync_WithNonExistingBusiness_ReturnsNotFound()
        {
            //Arrange 
            var business = (Business)null;
            _mediatorStub.Setup(m => m.Send(It.IsAny<Edit.Command>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value);
            var controller = new BusinessesController(_mediatorStub.Object);

            //Act
            var result = await controller.EditBusiness(Guid.NewGuid(), business);

            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task EditBusinessAsync_WithExistingBusiness_ReturnOk()
        {
            //To discuss, why is it the same to create???
            //Arrange 
            var businessToEdit = CreateRandomBusiness();
            var id = businessToEdit.Id;
            _mediatorStub.Setup(m => m.Send(It.IsAny<Edit.Command>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value);
            var controller = new BusinessesController(_mediatorStub.Object);
            
            //Act
            //var result = await controller.EditBusiness(id, businessToEdit);

            //Assert
            //result.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public async Task DeleteBusinessAsync_WithExistingBusiness_ReturnOk()
        {
            //TODO:
            throw new NotImplementedException();
        }
        
        

        #region Private Methods

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
                CreatedDate = DateTimeOffset.UtcNow,
                UpdatedDate = DateTimeOffset.UtcNow,
                CategoryId = 1,
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Description2 = Guid.NewGuid().ToString(),
                Description3 = Guid.NewGuid().ToString(),
                Emails = new List<Email>(),
                Phones = new List<Phone>(),
                Addresses = new List<Address>(),
                Website = Guid.NewGuid().ToString(),
                Abn = Guid.NewGuid().ToString()
            };

        }
            #endregion
    }
}