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
    public partial interface IShippingAddressService
    {
        Task<Response<ShippingAddressDto>> InsertAsync(ShippingAddressDto request);
        Task<Response<bool>> DeleteAsync(ShippingAddressDto request);
        Task<Response<bool>> UpdateAsync(int id, ShippingAddressDto request);
        Task<Response<List<ShippingAddressDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ShippingAddressDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerResponseDto>>> GetByCustomerAsync(int shippingAddressesCustomerId, int? page, int? size);
        Task<Response<List<GetOrdersForShippingAddressesResponseDto>>> GetOrdersForShippingAddressesAsync(int shippingAddressesId);
        Task<Response<GetOrdersForShippingAddressesResponseDto>> GetOrdersForShippingAddressesDetailsAsync(int shippingAddressesId, int ordersId);
    }
}