using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.OrderModule.Application.Services.BillingAddress;
using QuickCode.DemoTest.OrderModule.Application.Dtos.BillingAddress;
using QuickCode.DemoTest.OrderModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.Common.Helpers;
using QuickCode.DemoTest.Common.Models;

namespace QuickCode.DemoTest.OrderModule.Application.Tests.Services.BillingAddress
{
    public class InsertBillingAddressCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IBillingAddressRepository> _repositoryMock;
        private readonly Mock<ILogger<BillingAddressService>> _loggerMock;
        private readonly BillingAddressService _service;
        public InsertBillingAddressCommandTests()
        {
            _repositoryMock = new Mock<IBillingAddressRepository>();
            _loggerMock = new Mock<ILogger<BillingAddressService>>();
            _service = new BillingAddressService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<BillingAddressDto>("tr");
            var fakeResponse = new RepoResponse<BillingAddressDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<BillingAddressDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<BillingAddressDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<BillingAddressDto>("tr");
            var fakeResponse = new RepoResponse<BillingAddressDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<BillingAddressDto>())).ReturnsAsync(fakeResponse);
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