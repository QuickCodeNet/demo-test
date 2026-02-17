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
    public partial interface IProductCategoryService
    {
        Task<Response<ProductCategoryDto>> InsertAsync(ProductCategoryDto request);
        Task<Response<bool>> DeleteAsync(ProductCategoryDto request);
        Task<Response<bool>> UpdateAsync(int id, ProductCategoryDto request);
        Task<Response<List<ProductCategoryDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ProductCategoryDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool productCategoriesIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string productCategoriesName, int? page, int? size);
        Task<Response<List<GetByParentResponseDto>>> GetByParentAsync(int productCategoriesParentCategoryId, int? page, int? size);
        Task<Response<List<GetProductsForProductCategoriesResponseDto>>> GetProductsForProductCategoriesAsync(int productCategoriesId);
        Task<Response<GetProductsForProductCategoriesResponseDto>> GetProductsForProductCategoriesDetailsAsync(int productCategoriesId, int productsId);
    }
}