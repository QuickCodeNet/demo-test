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
    public partial interface IPaymentMethodService
    {
        Task<Response<PaymentMethodDto>> InsertAsync(PaymentMethodDto request);
        Task<Response<bool>> DeleteAsync(PaymentMethodDto request);
        Task<Response<bool>> UpdateAsync(int id, PaymentMethodDto request);
        Task<Response<List<PaymentMethodDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<PaymentMethodDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerResponseDto>>> GetByCustomerAsync(int paymentMethodsCustomerId, int? page, int? size);
        Task<Response<List<GetOrdersForPaymentMethodsResponseDto>>> GetOrdersForPaymentMethodsAsync(int paymentMethodsId);
        Task<Response<GetOrdersForPaymentMethodsResponseDto>> GetOrdersForPaymentMethodsDetailsAsync(int paymentMethodsId, int ordersId);
    }
}