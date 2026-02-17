using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Entities;
using QuickCode.DemoTest.ProductCatalogModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ProductCatalogModule.Application.Dtos.ProductImage;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoTest.ProductCatalogModule.Application.Services.ProductImage
{
    public partial interface IProductImageService
    {
        Task<Response<ProductImageDto>> InsertAsync(ProductImageDto request);
        Task<Response<bool>> DeleteAsync(ProductImageDto request);
        Task<Response<bool>> UpdateAsync(int id, ProductImageDto request);
        Task<Response<List<ProductImageDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ProductImageDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int productImagesProductId, int? page, int? size);
        Task<Response<int>> SetPrimaryAsync(int productImagesId, SetPrimaryRequestDto updateRequest);
    }
}