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
    public partial interface IProductService
    {
        Task<Response<ProductDto>> InsertAsync(ProductDto request);
        Task<Response<bool>> DeleteAsync(ProductDto request);
        Task<Response<bool>> UpdateAsync(int id, ProductDto request);
        Task<Response<List<ProductDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ProductDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(ProductStatus productsStatus, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string productsName, int? page, int? size);
        Task<Response<List<GetByCategoryResponseDto>>> GetByCategoryAsync(int productsCategoryId, int? page, int? size);
        Task<Response<List<GetByPriceRangeResponseDto>>> GetByPriceRangeAsync(decimal productsPrice, int? page, int? size);
        Task<Response<List<GetNewestResponseDto>>> GetNewestAsync(int? page, int? size);
        Task<Response<List<GetProductImagesForProductsResponseDto>>> GetProductImagesForProductsAsync(int productsId);
        Task<Response<GetProductImagesForProductsResponseDto>> GetProductImagesForProductsDetailsAsync(int productsId, int productImagesId);
        Task<Response<List<GetProductReviewsForProductsResponseDto>>> GetProductReviewsForProductsAsync(int productsId);
        Task<Response<GetProductReviewsForProductsResponseDto>> GetProductReviewsForProductsDetailsAsync(int productsId, int productReviewsId);
        Task<Response<List<GetProductSpecificationsForProductsResponseDto>>> GetProductSpecificationsForProductsAsync(int productsId);
        Task<Response<GetProductSpecificationsForProductsResponseDto>> GetProductSpecificationsForProductsDetailsAsync(int productsId, int productSpecificationsId);
        Task<Response<int>> UpdatePriceAsync(int productsId, UpdatePriceRequestDto updateRequest);
    }
}