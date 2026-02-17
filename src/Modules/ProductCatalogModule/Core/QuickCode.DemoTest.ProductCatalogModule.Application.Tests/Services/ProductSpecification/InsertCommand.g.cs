using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.ProductCatalogModule.Application.Services.ProductSpecification;
using QuickCode.DemoTest.ProductCatalogModule.Application.Dtos.ProductSpecification;
using QuickCode.DemoTest.ProductCatalogModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.Common.Helpers;
using QuickCode.DemoTest.Common.Models;

namespace QuickCode.DemoTest.ProductCatalogModule.Application.Tests.Services.ProductSpecification
{
    public class InsertProductSpecificationCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IProductSpecificationRepository> _repositoryMock;
        private readonly Mock<ILogger<ProductSpecificationService>> _loggerMock;
        private readonly ProductSpecificationService _service;
        public InsertProductSpecificationCommandTests()
        {
            _repositoryMock = new Mock<IProductSpecificationRepository>();
            _loggerMock = new Mock<ILogger<ProductSpecificationService>>();
            _service = new ProductSpecificationService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ProductSpecificationDto>("tr");
            var fakeResponse = new RepoResponse<ProductSpecificationDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<ProductSpecificationDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<ProductSpecificationDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ProductSpecificationDto>("tr");
            var fakeResponse = new RepoResponse<ProductSpecificationDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<ProductSpecificationDto>())).ReturnsAsync(fakeResponse);
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