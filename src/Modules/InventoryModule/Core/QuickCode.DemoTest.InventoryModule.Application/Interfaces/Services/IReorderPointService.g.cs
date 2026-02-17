using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.InventoryModule.Domain.Entities;
using QuickCode.DemoTest.InventoryModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.InventoryModule.Application.Dtos.ReorderPoint;

namespace QuickCode.DemoTest.InventoryModule.Application.Services.ReorderPoint
{
    public partial interface IReorderPointService
    {
        Task<Response<ReorderPointDto>> InsertAsync(ReorderPointDto request);
        Task<Response<bool>> DeleteAsync(ReorderPointDto request);
        Task<Response<bool>> UpdateAsync(int id, ReorderPointDto request);
        Task<Response<List<ReorderPointDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ReorderPointDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int reorderPointsProductId, int? page, int? size);
    }
}