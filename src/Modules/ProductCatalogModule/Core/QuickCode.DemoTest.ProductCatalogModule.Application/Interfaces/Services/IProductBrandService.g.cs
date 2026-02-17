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
    public partial interface IProductBrandService
    {
        Task<Response<ProductBrandDto>> InsertAsync(ProductBrandDto request);
        Task<Response<bool>> DeleteAsync(ProductBrandDto request);
        Task<Response<bool>> UpdateAsync(int id, ProductBrandDto request);
        Task<Response<List<ProductBrandDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ProductBrandDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool productBrandsIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string productBrandsName, int? page, int? size);
        Task<Response<List<GetProductsForProductBrandsResponseDto>>> GetProductsForProductBrandsAsync(int productBrandsId);
        Task<Response<GetProductsForProductBrandsResponseDto>> GetProductsForProductBrandsDetailsAsync(int productBrandsId, int productsId);
    }
}