using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.ShippingModule.Application.Services.DeliveryException;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.DeliveryException;
using QuickCode.DemoTest.ShippingModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.Common.Helpers;
using QuickCode.DemoTest.Common.Models;

namespace QuickCode.DemoTest.ShippingModule.Application.Tests.Services.DeliveryException
{
    public class InsertDeliveryExceptionCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IDeliveryExceptionRepository> _repositoryMock;
        private readonly Mock<ILogger<DeliveryExceptionService>> _loggerMock;
        private readonly DeliveryExceptionService _service;
        public InsertDeliveryExceptionCommandTests()
        {
            _repositoryMock = new Mock<IDeliveryExceptionRepository>();
            _loggerMock = new Mock<ILogger<DeliveryExceptionService>>();
            _service = new DeliveryExceptionService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<DeliveryExceptionDto>("tr");
            var fakeResponse = new RepoResponse<DeliveryExceptionDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<DeliveryExceptionDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<DeliveryExceptionDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<DeliveryExceptionDto>("tr");
            var fakeResponse = new RepoResponse<DeliveryExceptionDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<DeliveryExceptionDto>())).ReturnsAsync(fakeResponse);
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