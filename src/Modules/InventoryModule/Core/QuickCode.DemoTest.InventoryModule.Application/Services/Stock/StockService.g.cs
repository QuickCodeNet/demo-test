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
    public partial class StockService : IStockService
    {
        private readonly ILogger<StockService> _logger;
        private readonly IStockRepository _repository;
        public StockService(ILogger<StockService> logger, IStockRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<StockDto>> InsertAsync(StockDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(StockDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, StockDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<StockDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<StockDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int stocksProductId, int? page, int? size)
        {
            var returnValue = await _repository.GetByProductAsync(stocksProductId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByWarehouseResponseDto>>> GetByWarehouseAsync(int stocksWarehouseId, int? page, int? size)
        {
            var returnValue = await _repository.GetByWarehouseAsync(stocksWarehouseId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<long>> GetLowStockAsync()
        {
            var returnValue = await _repository.GetLowStockAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> AdjustStockAsync(int stocksProductId, int stocksWarehouseId, AdjustStockRequestDto updateRequest)
        {
            var returnValue = await _repository.AdjustStockAsync(stocksProductId, stocksWarehouseId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}