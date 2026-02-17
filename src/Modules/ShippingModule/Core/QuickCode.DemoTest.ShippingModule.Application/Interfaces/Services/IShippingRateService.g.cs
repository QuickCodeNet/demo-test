using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ShippingModule.Domain.Entities;
using QuickCode.DemoTest.ShippingModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.ShippingRate;
using QuickCode.DemoTest.ShippingModule.Domain.Enums;

namespace QuickCode.DemoTest.ShippingModule.Application.Services.ShippingRate
{
    public partial interface IShippingRateService
    {
        Task<Response<ShippingRateDto>> InsertAsync(ShippingRateDto request);
        Task<Response<bool>> DeleteAsync(ShippingRateDto request);
        Task<Response<bool>> UpdateAsync(int id, ShippingRateDto request);
        Task<Response<List<ShippingRateDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ShippingRateDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCarrierAndZipResponseDto>>> GetByCarrierAndZipAsync(int shippingRatesCarrierId, string shippingRatesDestinationZipCode, int? page, int? size);
    }
}