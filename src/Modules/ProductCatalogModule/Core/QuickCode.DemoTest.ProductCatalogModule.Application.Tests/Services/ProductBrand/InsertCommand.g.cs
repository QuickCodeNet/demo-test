using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.ProductCatalogModule.Application.Services.ProductBrand;
using QuickCode.DemoTest.ProductCatalogModule.Application.Dtos.ProductBrand;
using QuickCode.DemoTest.ProductCatalogModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.Common.Helpers;
using QuickCode.DemoTest.Common.Models;

namespace QuickCode.DemoTest.ProductCatalogModule.Application.Tests.Services.ProductBrand
{
    public class InsertProductBrandCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IProductBrandRepository> _repositoryMock;
        private readonly Mock<ILogger<ProductBrandService>> _loggerMock;
        private readonly ProductBrandService _service;
        public InsertProductBrandCommandTests()
        {
            _repositoryMock = new Mock<IProductBrandRepository>();
            _loggerMock = new Mock<ILogger<ProductBrandService>>();
            _service = new ProductBrandService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ProductBrandDto>("tr");
            var fakeResponse = new RepoResponse<ProductBrandDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<ProductBrandDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<ProductBrandDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ProductBrandDto>("tr");
            var fakeResponse = new RepoResponse<ProductBrandDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<ProductBrandDto>())).ReturnsAsync(fakeResponse);
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