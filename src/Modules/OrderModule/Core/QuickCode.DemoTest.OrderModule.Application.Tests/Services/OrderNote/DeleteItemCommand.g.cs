using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.OrderModule.Application.Services.OrderNote;
using QuickCode.DemoTest.OrderModule.Application.Dtos.OrderNote;
using QuickCode.DemoTest.OrderModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.Common.Helpers;
using QuickCode.DemoTest.Common.Models;

namespace QuickCode.DemoTest.OrderModule.Application.Tests.Services.OrderNote
{
    public class OrderNoteServiceDeleteTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IOrderNoteRepository> _repositoryMock;
        private readonly Mock<ILogger<OrderNoteService>> _loggerMock;
        private readonly OrderNoteService _service;
        public OrderNoteServiceDeleteTests()
        {
            _repositoryMock = new Mock<IOrderNoteRepository>();
            _loggerMock = new Mock<ILogger<OrderNoteService>>();
            _service = new OrderNoteService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<OrderNoteDto>("tr");
            var fakeGetResponse = new RepoResponse<OrderNoteDto>(fakeDto, "Success");
            var fakeDeleteResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<OrderNoteDto>())).ReturnsAsync(fakeDeleteResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<OrderNoteDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            var fakeDto = TestDataGenerator.CreateFake<OrderNoteDto>("tr");
            // Arrange
            var fakeGetResponse = new RepoResponse<OrderNoteDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<OrderNoteDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}