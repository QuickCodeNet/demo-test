using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Entities;
using QuickCode.DemoTest.ProductCatalogModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ProductCatalogModule.Application.Dtos.ProductSpecification;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoTest.ProductCatalogModule.Application.Services.ProductSpecification
{
    public partial interface IProductSpecificationService
    {
        Task<Response<ProductSpecificationDto>> InsertAsync(ProductSpecificationDto request);
        Task<Response<bool>> DeleteAsync(ProductSpecificationDto request);
        Task<Response<bool>> UpdateAsync(int id, ProductSpecificationDto request);
        Task<Response<List<ProductSpecificationDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ProductSpecificationDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int productSpecificationsProductId, int? page, int? size);
    }
}