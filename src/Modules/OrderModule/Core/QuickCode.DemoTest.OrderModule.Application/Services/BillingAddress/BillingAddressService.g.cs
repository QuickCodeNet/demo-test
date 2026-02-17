using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.OrderModule.Domain.Entities;
using QuickCode.DemoTest.OrderModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.OrderModule.Application.Dtos.BillingAddress;
using QuickCode.DemoTest.OrderModule.Domain.Enums;

namespace QuickCode.DemoTest.OrderModule.Application.Services.BillingAddress
{
    public partial class BillingAddressService : IBillingAddressService
    {
        private readonly ILogger<BillingAddressService> _logger;
        private readonly IBillingAddressRepository _repository;
        public BillingAddressService(ILogger<BillingAddressService> logger, IBillingAddressRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<BillingAddressDto>> InsertAsync(BillingAddressDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(BillingAddressDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, BillingAddressDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<BillingAddressDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<BillingAddressDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCustomerResponseDto>>> GetByCustomerAsync(int billingAddressesCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerAsync(billingAddressesCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetOrdersForBillingAddressesResponseDto>>> GetOrdersForBillingAddressesAsync(int billingAddressesId)
        {
            var returnValue = await _repository.GetOrdersForBillingAddressesAsync(billingAddressesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetOrdersForBillingAddressesResponseDto>> GetOrdersForBillingAddressesDetailsAsync(int billingAddressesId, int ordersId)
        {
            var returnValue = await _repository.GetOrdersForBillingAddressesDetailsAsync(billingAddressesId, ordersId);
            return returnValue.ToResponse();
        }
    }
}