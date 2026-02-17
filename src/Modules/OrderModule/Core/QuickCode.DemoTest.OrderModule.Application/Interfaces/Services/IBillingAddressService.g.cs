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
    public partial interface IBillingAddressService
    {
        Task<Response<BillingAddressDto>> InsertAsync(BillingAddressDto request);
        Task<Response<bool>> DeleteAsync(BillingAddressDto request);
        Task<Response<bool>> UpdateAsync(int id, BillingAddressDto request);
        Task<Response<List<BillingAddressDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<BillingAddressDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerResponseDto>>> GetByCustomerAsync(int billingAddressesCustomerId, int? page, int? size);
        Task<Response<List<GetOrdersForBillingAddressesResponseDto>>> GetOrdersForBillingAddressesAsync(int billingAddressesId);
        Task<Response<GetOrdersForBillingAddressesResponseDto>> GetOrdersForBillingAddressesDetailsAsync(int billingAddressesId, int ordersId);
    }
}