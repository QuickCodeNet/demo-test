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
    public partial class InventoryAdjustmentService : IInventoryAdjustmentService
    {
        private readonly ILogger<InventoryAdjustmentService> _logger;
        private readonly IInventoryAdjustmentRepository _repository;
        public InventoryAdjustmentService(ILogger<InventoryAdjustmentService> logger, IInventoryAdjustmentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<InventoryAdjustmentDto>> InsertAsync(InventoryAdjustmentDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(InventoryAdjustmentDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, InventoryAdjustmentDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<InventoryAdjustmentDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<InventoryAdjustmentDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int inventoryAdjustmentsProductId, int? page, int? size)
        {
            var returnValue = await _repository.GetByProductAsync(inventoryAdjustmentsProductId, page, size);
            return returnValue.ToResponse();
        }
    }
}