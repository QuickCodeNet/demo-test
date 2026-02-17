using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.InventoryModule.Domain.Entities;
using QuickCode.DemoTest.InventoryModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.InventoryModule.Application.Dtos.StockMovement;

namespace QuickCode.DemoTest.InventoryModule.Application.Services.StockMovement
{
    public partial interface IStockMovementService
    {
        Task<Response<StockMovementDto>> InsertAsync(StockMovementDto request);
        Task<Response<bool>> DeleteAsync(StockMovementDto request);
        Task<Response<bool>> UpdateAsync(int id, StockMovementDto request);
        Task<Response<List<StockMovementDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<StockMovementDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int stockMovementsProductId, int? page, int? size);
    }
}