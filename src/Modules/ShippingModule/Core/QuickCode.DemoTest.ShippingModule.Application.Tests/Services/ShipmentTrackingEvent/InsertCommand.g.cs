using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.ShippingModule.Application.Services.ShipmentTrackingEvent;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.ShipmentTrackingEvent;
using QuickCode.DemoTest.ShippingModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.Common.Helpers;
using QuickCode.DemoTest.Common.Models;

namespace QuickCode.DemoTest.ShippingModule.Application.Tests.Services.ShipmentTrackingEvent
{
    public class InsertShipmentTrackingEventCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IShipmentTrackingEventRepository> _repositoryMock;
        private readonly Mock<ILogger<ShipmentTrackingEventService>> _loggerMock;
        private readonly ShipmentTrackingEventService _service;
        public InsertShipmentTrackingEventCommandTests()
        {
            _repositoryMock = new Mock<IShipmentTrackingEventRepository>();
            _loggerMock = new Mock<ILogger<ShipmentTrackingEventService>>();
            _service = new ShipmentTrackingEventService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ShipmentTrackingEventDto>("tr");
            var fakeResponse = new RepoResponse<ShipmentTrackingEventDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<ShipmentTrackingEventDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<ShipmentTrackingEventDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ShipmentTrackingEventDto>("tr");
            var fakeResponse = new RepoResponse<ShipmentTrackingEventDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<ShipmentTrackingEventDto>())).ReturnsAsync(fakeResponse);
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