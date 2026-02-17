using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ShippingModule.Domain.Entities;
using QuickCode.DemoTest.ShippingModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.ShippingCarrier;
using QuickCode.DemoTest.ShippingModule.Domain.Enums;

namespace QuickCode.DemoTest.ShippingModule.Application.Services.ShippingCarrier
{
    public partial class ShippingCarrierService : IShippingCarrierService
    {
        private readonly ILogger<ShippingCarrierService> _logger;
        private readonly IShippingCarrierRepository _repository;
        public ShippingCarrierService(ILogger<ShippingCarrierService> logger, IShippingCarrierRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ShippingCarrierDto>> InsertAsync(ShippingCarrierDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ShippingCarrierDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ShippingCarrierDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ShippingCarrierDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ShippingCarrierDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool shippingCarriersIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(shippingCarriersIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetShipmentsForShippingCarriersResponseDto>>> GetShipmentsForShippingCarriersAsync(int shippingCarriersId)
        {
            var returnValue = await _repository.GetShipmentsForShippingCarriersAsync(shippingCarriersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetShipmentsForShippingCarriersResponseDto>> GetShipmentsForShippingCarriersDetailsAsync(int shippingCarriersId, int shipmentsId)
        {
            var returnValue = await _repository.GetShipmentsForShippingCarriersDetailsAsync(shippingCarriersId, shipmentsId);
            return returnValue.ToResponse();
        }
    }
}