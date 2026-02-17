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
    public partial class StockMovementService : IStockMovementService
    {
        private readonly ILogger<StockMovementService> _logger;
        private readonly IStockMovementRepository _repository;
        public StockMovementService(ILogger<StockMovementService> logger, IStockMovementRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<StockMovementDto>> InsertAsync(StockMovementDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(StockMovementDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, StockMovementDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<StockMovementDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<StockMovementDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int stockMovementsProductId, int? page, int? size)
        {
            var returnValue = await _repository.GetByProductAsync(stockMovementsProductId, page, size);
            return returnValue.ToResponse();
        }
    }
}