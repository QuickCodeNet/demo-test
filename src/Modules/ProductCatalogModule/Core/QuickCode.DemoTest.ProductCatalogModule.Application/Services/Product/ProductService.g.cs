using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Entities;
using QuickCode.DemoTest.ProductCatalogModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ProductCatalogModule.Application.Dtos.Product;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoTest.ProductCatalogModule.Application.Services.Product
{
    public partial class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _repository;
        public ProductService(ILogger<ProductService> logger, IProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ProductDto>> InsertAsync(ProductDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ProductDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ProductDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ProductDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ProductDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(ProductStatus productsStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(productsStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string productsName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(productsName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByCategoryResponseDto>>> GetByCategoryAsync(int productsCategoryId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCategoryAsync(productsCategoryId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByPriceRangeResponseDto>>> GetByPriceRangeAsync(decimal productsPrice, int? page, int? size)
        {
            var returnValue = await _repository.GetByPriceRangeAsync(productsPrice, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetNewestResponseDto>>> GetNewestAsync(int? page, int? size)
        {
            var returnValue = await _repository.GetNewestAsync(page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetProductImagesForProductsResponseDto>>> GetProductImagesForProductsAsync(int productsId)
        {
            var returnValue = await _repository.GetProductImagesForProductsAsync(productsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetProductImagesForProductsResponseDto>> GetProductImagesForProductsDetailsAsync(int productsId, int productImagesId)
        {
            var returnValue = await _repository.GetProductImagesForProductsDetailsAsync(productsId, productImagesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetProductReviewsForProductsResponseDto>>> GetProductReviewsForProductsAsync(int productsId)
        {
            var returnValue = await _repository.GetProductReviewsForProductsAsync(productsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetProductReviewsForProductsResponseDto>> GetProductReviewsForProductsDetailsAsync(int productsId, int productReviewsId)
        {
            var returnValue = await _repository.GetProductReviewsForProductsDetailsAsync(productsId, productReviewsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetProductSpecificationsForProductsResponseDto>>> GetProductSpecificationsForProductsAsync(int productsId)
        {
            var returnValue = await _repository.GetProductSpecificationsForProductsAsync(productsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetProductSpecificationsForProductsResponseDto>> GetProductSpecificationsForProductsDetailsAsync(int productsId, int productSpecificationsId)
        {
            var returnValue = await _repository.GetProductSpecificationsForProductsDetailsAsync(productsId, productSpecificationsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdatePriceAsync(int productsId, UpdatePriceRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdatePriceAsync(productsId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}