using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.InventoryModule.Domain.Entities;
using QuickCode.DemoTest.InventoryModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.InventoryModule.Application.Dtos.Stock;

namespace QuickCode.DemoTest.InventoryModule.Application.Services.Stock
{
    public partial interface IStockService
    {
        Task<Response<StockDto>> InsertAsync(StockDto request);
        Task<Response<bool>> DeleteAsync(StockDto request);
        Task<Response<bool>> UpdateAsync(int id, StockDto request);
        Task<Response<List<StockDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<StockDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int stocksProductId, int? page, int? size);
        Task<Response<List<GetByWarehouseResponseDto>>> GetByWarehouseAsync(int stocksWarehouseId, int? page, int? size);
        Task<Response<long>> GetLowStockAsync();
        Task<Response<int>> AdjustStockAsync(int stocksProductId, int stocksWarehouseId, AdjustStockRequestDto updateRequest);
    }
}