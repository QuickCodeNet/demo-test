using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.InventoryModule.Domain.Entities;
using QuickCode.DemoTest.InventoryModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.InventoryModule.Application.Dtos.Warehouse;

namespace QuickCode.DemoTest.InventoryModule.Application.Services.Warehouse
{
    public partial interface IWarehouseService
    {
        Task<Response<WarehouseDto>> InsertAsync(WarehouseDto request);
        Task<Response<bool>> DeleteAsync(WarehouseDto request);
        Task<Response<bool>> UpdateAsync(int id, WarehouseDto request);
        Task<Response<List<WarehouseDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<WarehouseDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool warehousesIsActive, int? page, int? size);
        Task<Response<List<GetStocksForWarehousesResponseDto>>> GetStocksForWarehousesAsync(int warehousesId);
        Task<Response<GetStocksForWarehousesResponseDto>> GetStocksForWarehousesDetailsAsync(int warehousesId, int stocksId);
        Task<Response<List<GetStockMovementsForWarehousesResponseDto>>> GetStockMovementsForWarehousesAsync(int warehousesId);
        Task<Response<GetStockMovementsForWarehousesResponseDto>> GetStockMovementsForWarehousesDetailsAsync(int warehousesId, int stockMovementsId);
        Task<Response<List<GetReorderPointsForWarehousesResponseDto>>> GetReorderPointsForWarehousesAsync(int warehousesId);
        Task<Response<GetReorderPointsForWarehousesResponseDto>> GetReorderPointsForWarehousesDetailsAsync(int warehousesId, int reorderPointsId);
        Task<Response<List<GetInventoryAdjustmentsForWarehousesResponseDto>>> GetInventoryAdjustmentsForWarehousesAsync(int warehousesId);
        Task<Response<GetInventoryAdjustmentsForWarehousesResponseDto>> GetInventoryAdjustmentsForWarehousesDetailsAsync(int warehousesId, int inventoryAdjustmentsId);
    }
}