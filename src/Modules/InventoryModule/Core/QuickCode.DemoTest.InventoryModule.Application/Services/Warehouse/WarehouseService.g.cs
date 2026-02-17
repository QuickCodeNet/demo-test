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
    public partial class WarehouseService : IWarehouseService
    {
        private readonly ILogger<WarehouseService> _logger;
        private readonly IWarehouseRepository _repository;
        public WarehouseService(ILogger<WarehouseService> logger, IWarehouseRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<WarehouseDto>> InsertAsync(WarehouseDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(WarehouseDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, WarehouseDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<WarehouseDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<WarehouseDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool warehousesIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(warehousesIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetStocksForWarehousesResponseDto>>> GetStocksForWarehousesAsync(int warehousesId)
        {
            var returnValue = await _repository.GetStocksForWarehousesAsync(warehousesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetStocksForWarehousesResponseDto>> GetStocksForWarehousesDetailsAsync(int warehousesId, int stocksId)
        {
            var returnValue = await _repository.GetStocksForWarehousesDetailsAsync(warehousesId, stocksId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetStockMovementsForWarehousesResponseDto>>> GetStockMovementsForWarehousesAsync(int warehousesId)
        {
            var returnValue = await _repository.GetStockMovementsForWarehousesAsync(warehousesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetStockMovementsForWarehousesResponseDto>> GetStockMovementsForWarehousesDetailsAsync(int warehousesId, int stockMovementsId)
        {
            var returnValue = await _repository.GetStockMovementsForWarehousesDetailsAsync(warehousesId, stockMovementsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetReorderPointsForWarehousesResponseDto>>> GetReorderPointsForWarehousesAsync(int warehousesId)
        {
            var returnValue = await _repository.GetReorderPointsForWarehousesAsync(warehousesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetReorderPointsForWarehousesResponseDto>> GetReorderPointsForWarehousesDetailsAsync(int warehousesId, int reorderPointsId)
        {
            var returnValue = await _repository.GetReorderPointsForWarehousesDetailsAsync(warehousesId, reorderPointsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetInventoryAdjustmentsForWarehousesResponseDto>>> GetInventoryAdjustmentsForWarehousesAsync(int warehousesId)
        {
            var returnValue = await _repository.GetInventoryAdjustmentsForWarehousesAsync(warehousesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetInventoryAdjustmentsForWarehousesResponseDto>> GetInventoryAdjustmentsForWarehousesDetailsAsync(int warehousesId, int inventoryAdjustmentsId)
        {
            var returnValue = await _repository.GetInventoryAdjustmentsForWarehousesDetailsAsync(warehousesId, inventoryAdjustmentsId);
            return returnValue.ToResponse();
        }
    }
}