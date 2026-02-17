using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Entities;
using QuickCode.DemoTest.ProductCatalogModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ProductCatalogModule.Application.Dtos.ProductCategory;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoTest.ProductCatalogModule.Application.Services.ProductCategory
{
    public partial class ProductCategoryService : IProductCategoryService
    {
        private readonly ILogger<ProductCategoryService> _logger;
        private readonly IProductCategoryRepository _repository;
        public ProductCategoryService(ILogger<ProductCategoryService> logger, IProductCategoryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ProductCategoryDto>> InsertAsync(ProductCategoryDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ProductCategoryDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ProductCategoryDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ProductCategoryDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ProductCategoryDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool productCategoriesIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(productCategoriesIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string productCategoriesName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(productCategoriesName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByParentResponseDto>>> GetByParentAsync(int productCategoriesParentCategoryId, int? page, int? size)
        {
            var returnValue = await _repository.GetByParentAsync(productCategoriesParentCategoryId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetProductsForProductCategoriesResponseDto>>> GetProductsForProductCategoriesAsync(int productCategoriesId)
        {
            var returnValue = await _repository.GetProductsForProductCategoriesAsync(productCategoriesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetProductsForProductCategoriesResponseDto>> GetProductsForProductCategoriesDetailsAsync(int productCategoriesId, int productsId)
        {
            var returnValue = await _repository.GetProductsForProductCategoriesDetailsAsync(productCategoriesId, productsId);
            return returnValue.ToResponse();
        }
    }
}