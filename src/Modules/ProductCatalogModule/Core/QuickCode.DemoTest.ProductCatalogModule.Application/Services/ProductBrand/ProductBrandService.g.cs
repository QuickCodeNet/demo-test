using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Entities;
using QuickCode.DemoTest.ProductCatalogModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ProductCatalogModule.Application.Dtos.ProductBrand;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoTest.ProductCatalogModule.Application.Services.ProductBrand
{
    public partial class ProductBrandService : IProductBrandService
    {
        private readonly ILogger<ProductBrandService> _logger;
        private readonly IProductBrandRepository _repository;
        public ProductBrandService(ILogger<ProductBrandService> logger, IProductBrandRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ProductBrandDto>> InsertAsync(ProductBrandDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ProductBrandDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ProductBrandDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ProductBrandDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ProductBrandDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool productBrandsIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(productBrandsIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string productBrandsName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(productBrandsName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetProductsForProductBrandsResponseDto>>> GetProductsForProductBrandsAsync(int productBrandsId)
        {
            var returnValue = await _repository.GetProductsForProductBrandsAsync(productBrandsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetProductsForProductBrandsResponseDto>> GetProductsForProductBrandsDetailsAsync(int productBrandsId, int productsId)
        {
            var returnValue = await _repository.GetProductsForProductBrandsDetailsAsync(productBrandsId, productsId);
            return returnValue.ToResponse();
        }
    }
}