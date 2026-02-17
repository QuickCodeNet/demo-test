using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.InventoryModule.Domain.Entities;
using QuickCode.DemoTest.InventoryModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.InventoryModule.Application.Dtos.InventoryAdjustment;

namespace QuickCode.DemoTest.InventoryModule.Application.Services.InventoryAdjustment
{
    public partial interface IInventoryAdjustmentService
    {
        Task<Response<InventoryAdjustmentDto>> InsertAsync(InventoryAdjustmentDto request);
        Task<Response<bool>> DeleteAsync(InventoryAdjustmentDto request);
        Task<Response<bool>> UpdateAsync(int id, InventoryAdjustmentDto request);
        Task<Response<List<InventoryAdjustmentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<InventoryAdjustmentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int inventoryAdjustmentsProductId, int? page, int? size);
    }
}