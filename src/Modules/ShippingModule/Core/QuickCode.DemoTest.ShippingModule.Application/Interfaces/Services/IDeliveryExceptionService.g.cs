using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ShippingModule.Domain.Entities;
using QuickCode.DemoTest.ShippingModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.DeliveryException;
using QuickCode.DemoTest.ShippingModule.Domain.Enums;

namespace QuickCode.DemoTest.ShippingModule.Application.Services.DeliveryException
{
    public partial interface IDeliveryExceptionService
    {
        Task<Response<DeliveryExceptionDto>> InsertAsync(DeliveryExceptionDto request);
        Task<Response<bool>> DeleteAsync(DeliveryExceptionDto request);
        Task<Response<bool>> UpdateAsync(int id, DeliveryExceptionDto request);
        Task<Response<List<DeliveryExceptionDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<DeliveryExceptionDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByShipmentResponseDto>>> GetByShipmentAsync(int deliveryExceptionsShipmentId, int? page, int? size);
    }
}