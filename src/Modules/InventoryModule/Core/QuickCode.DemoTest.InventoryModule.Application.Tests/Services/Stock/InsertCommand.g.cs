using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.InventoryModule.Application.Services.Stock;
using QuickCode.DemoTest.InventoryModule.Application.Dtos.Stock;
using QuickCode.DemoTest.InventoryModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.Common.Helpers;
using QuickCode.DemoTest.Common.Models;

namespace QuickCode.DemoTest.InventoryModule.Application.Tests.Services.Stock
{
    public class InsertStockCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IStockRepository> _repositoryMock;
        private readonly Mock<ILogger<StockService>> _loggerMock;
        private readonly StockService _service;
        public InsertStockCommandTests()
        {
            _repositoryMock = new Mock<IStockRepository>();
            _loggerMock = new Mock<ILogger<StockService>>();
            _service = new StockService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<StockDto>("tr");
            var fakeResponse = new RepoResponse<StockDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<StockDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<StockDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<StockDto>("tr");
            var fakeResponse = new RepoResponse<StockDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<StockDto>())).ReturnsAsync(fakeResponse);
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