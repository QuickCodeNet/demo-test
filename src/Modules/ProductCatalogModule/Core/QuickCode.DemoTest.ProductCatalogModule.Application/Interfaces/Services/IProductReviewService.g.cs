using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Entities;
using QuickCode.DemoTest.ProductCatalogModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ProductCatalogModule.Application.Dtos.ProductReview;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoTest.ProductCatalogModule.Application.Services.ProductReview
{
    public partial interface IProductReviewService
    {
        Task<Response<ProductReviewDto>> InsertAsync(ProductReviewDto request);
        Task<Response<bool>> DeleteAsync(ProductReviewDto request);
        Task<Response<bool>> UpdateAsync(int id, ProductReviewDto request);
        Task<Response<List<ProductReviewDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ProductReviewDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int productReviewsProductId, int? page, int? size);
        Task<Response<List<GetRecentResponseDto>>> GetRecentAsync(int productReviewsProductId, int? page, int? size);
    }
}