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
    public partial interface IDeliveryAddressService
    {
        Task<Response<DeliveryAddressDto>> InsertAsync(DeliveryAddressDto request);
        Task<Response<bool>> DeleteAsync(DeliveryAddressDto request);
        Task<Response<bool>> UpdateAsync(int id, DeliveryAddressDto request);
        Task<Response<List<DeliveryAddressDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<DeliveryAddressDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerResponseDto>>> GetByCustomerAsync(int deliveryAddressesCustomerId, int? page, int? size);
        Task<Response<List<GetShipmentsForDeliveryAddressesResponseDto>>> GetShipmentsForDeliveryAddressesAsync(int deliveryAddressesId);
        Task<Response<GetShipmentsForDeliveryAddressesResponseDto>> GetShipmentsForDeliveryAddressesDetailsAsync(int deliveryAddressesId, int shipmentsId);
    }
}