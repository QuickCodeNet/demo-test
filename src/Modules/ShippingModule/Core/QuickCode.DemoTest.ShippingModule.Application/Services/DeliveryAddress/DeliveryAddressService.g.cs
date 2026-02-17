using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ShippingModule.Domain.Entities;
using QuickCode.DemoTest.ShippingModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.DeliveryAddress;
using QuickCode.DemoTest.ShippingModule.Domain.Enums;

namespace QuickCode.DemoTest.ShippingModule.Application.Services.DeliveryAddress
{
    public partial class DeliveryAddressService : IDeliveryAddressService
    {
        private readonly ILogger<DeliveryAddressService> _logger;
        private readonly IDeliveryAddressRepository _repository;
        public DeliveryAddressService(ILogger<DeliveryAddressService> logger, IDeliveryAddressRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<DeliveryAddressDto>> InsertAsync(DeliveryAddressDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(DeliveryAddressDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, DeliveryAddressDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<DeliveryAddressDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<DeliveryAddressDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCustomerResponseDto>>> GetByCustomerAsync(int deliveryAddressesCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerAsync(deliveryAddressesCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetShipmentsForDeliveryAddressesResponseDto>>> GetShipmentsForDeliveryAddressesAsync(int deliveryAddressesId)
        {
            var returnValue = await _repository.GetShipmentsForDeliveryAddressesAsync(deliveryAddressesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetShipmentsForDeliveryAddressesResponseDto>> GetShipmentsForDeliveryAddressesDetailsAsync(int deliveryAddressesId, int shipmentsId)
        {
            var returnValue = await _repository.GetShipmentsForDeliveryAddressesDetailsAsync(deliveryAddressesId, shipmentsId);
            return returnValue.ToResponse();
        }
    }
}