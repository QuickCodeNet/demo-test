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
    public partial interface IShippingCarrierService
    {
        Task<Response<ShippingCarrierDto>> InsertAsync(ShippingCarrierDto request);
        Task<Response<bool>> DeleteAsync(ShippingCarrierDto request);
        Task<Response<bool>> UpdateAsync(int id, ShippingCarrierDto request);
        Task<Response<List<ShippingCarrierDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ShippingCarrierDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool shippingCarriersIsActive, int? page, int? size);
        Task<Response<List<GetShipmentsForShippingCarriersResponseDto>>> GetShipmentsForShippingCarriersAsync(int shippingCarriersId);
        Task<Response<GetShipmentsForShippingCarriersResponseDto>> GetShipmentsForShippingCarriersDetailsAsync(int shippingCarriersId, int shipmentsId);
    }
}