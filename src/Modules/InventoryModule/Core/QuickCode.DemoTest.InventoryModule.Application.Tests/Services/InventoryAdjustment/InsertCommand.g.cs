using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.InventoryModule.Application.Services.InventoryAdjustment;
using QuickCode.DemoTest.InventoryModule.Application.Dtos.InventoryAdjustment;
using QuickCode.DemoTest.InventoryModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.Common.Helpers;
using QuickCode.DemoTest.Common.Models;

namespace QuickCode.DemoTest.InventoryModule.Application.Tests.Services.InventoryAdjustment
{
    public class InsertInventoryAdjustmentCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IInventoryAdjustmentRepository> _repositoryMock;
        private readonly Mock<ILogger<InventoryAdjustmentService>> _loggerMock;
        private readonly InventoryAdjustmentService _service;
        public InsertInventoryAdjustmentCommandTests()
        {
            _repositoryMock = new Mock<IInventoryAdjustmentRepository>();
            _loggerMock = new Mock<ILogger<InventoryAdjustmentService>>();
            _service = new InventoryAdjustmentService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InventoryAdjustmentDto>("tr");
            var fakeResponse = new RepoResponse<InventoryAdjustmentDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<InventoryAdjustmentDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<InventoryAdjustmentDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<InventoryAdjustmentDto>("tr");
            var fakeResponse = new RepoResponse<InventoryAdjustmentDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<InventoryAdjustmentDto>())).ReturnsAsync(fakeResponse);
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