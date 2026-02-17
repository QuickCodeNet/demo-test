using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.ShippingModule.Application.Services.DeliveryAddress;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.DeliveryAddress;
using QuickCode.DemoTest.ShippingModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.Common.Helpers;
using QuickCode.DemoTest.Common.Models;

namespace QuickCode.DemoTest.ShippingModule.Application.Tests.Services.DeliveryAddress
{
    public class InsertDeliveryAddressCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IDeliveryAddressRepository> _repositoryMock;
        private readonly Mock<ILogger<DeliveryAddressService>> _loggerMock;
        private readonly DeliveryAddressService _service;
        public InsertDeliveryAddressCommandTests()
        {
            _repositoryMock = new Mock<IDeliveryAddressRepository>();
            _loggerMock = new Mock<ILogger<DeliveryAddressService>>();
            _service = new DeliveryAddressService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<DeliveryAddressDto>("tr");
            var fakeResponse = new RepoResponse<DeliveryAddressDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<DeliveryAddressDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<DeliveryAddressDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<DeliveryAddressDto>("tr");
            var fakeResponse = new RepoResponse<DeliveryAddressDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<DeliveryAddressDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.Null(result.Value);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}