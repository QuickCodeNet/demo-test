using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.OrderModule.Domain.Entities;
using QuickCode.DemoTest.OrderModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.OrderModule.Application.Dtos.ShippingAddress;
using QuickCode.DemoTest.OrderModule.Domain.Enums;

namespace QuickCode.DemoTest.OrderModule.Application.Services.ShippingAddress
{
    public partial class ShippingAddressService : IShippingAddressService
    {
        private readonly ILogger<ShippingAddressService> _logger;
        private readonly IShippingAddressRepository _repository;
        public ShippingAddressService(ILogger<ShippingAddressService> logger, IShippingAddressRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ShippingAddressDto>> InsertAsync(ShippingAddressDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ShippingAddressDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ShippingAddressDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ShippingAddressDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ShippingAddressDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCustomerResponseDto>>> GetByCustomerAsync(int shippingAddressesCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerAsync(shippingAddressesCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetOrdersForShippingAddressesResponseDto>>> GetOrdersForShippingAddressesAsync(int shippingAddressesId)
        {
            var returnValue = await _repository.GetOrdersForShippingAddressesAsync(shippingAddressesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetOrdersForShippingAddressesResponseDto>> GetOrdersForShippingAddressesDetailsAsync(int shippingAddressesId, int ordersId)
        {
            var returnValue = await _repository.GetOrdersForShippingAddressesDetailsAsync(shippingAddressesId, ordersId);
            return returnValue.ToResponse();
        }
    }
}