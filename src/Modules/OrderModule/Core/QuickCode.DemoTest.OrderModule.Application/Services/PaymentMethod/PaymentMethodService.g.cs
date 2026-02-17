using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.OrderModule.Domain.Entities;
using QuickCode.DemoTest.OrderModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.OrderModule.Application.Dtos.PaymentMethod;
using QuickCode.DemoTest.OrderModule.Domain.Enums;

namespace QuickCode.DemoTest.OrderModule.Application.Services.PaymentMethod
{
    public partial class PaymentMethodService : IPaymentMethodService
    {
        private readonly ILogger<PaymentMethodService> _logger;
        private readonly IPaymentMethodRepository _repository;
        public PaymentMethodService(ILogger<PaymentMethodService> logger, IPaymentMethodRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<PaymentMethodDto>> InsertAsync(PaymentMethodDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(PaymentMethodDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, PaymentMethodDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<PaymentMethodDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<PaymentMethodDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCustomerResponseDto>>> GetByCustomerAsync(int paymentMethodsCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerAsync(paymentMethodsCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetOrdersForPaymentMethodsResponseDto>>> GetOrdersForPaymentMethodsAsync(int paymentMethodsId)
        {
            var returnValue = await _repository.GetOrdersForPaymentMethodsAsync(paymentMethodsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetOrdersForPaymentMethodsResponseDto>> GetOrdersForPaymentMethodsDetailsAsync(int paymentMethodsId, int ordersId)
        {
            var returnValue = await _repository.GetOrdersForPaymentMethodsDetailsAsync(paymentMethodsId, ordersId);
            return returnValue.ToResponse();
        }
    }
}