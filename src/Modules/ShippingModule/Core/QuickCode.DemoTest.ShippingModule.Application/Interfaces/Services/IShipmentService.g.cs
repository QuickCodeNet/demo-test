using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ShippingModule.Domain.Entities;
using QuickCode.DemoTest.ShippingModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.Shipment;
using QuickCode.DemoTest.ShippingModule.Domain.Enums;

namespace QuickCode.DemoTest.ShippingModule.Application.Services.Shipment
{
    public partial interface IShipmentService
    {
        Task<Response<ShipmentDto>> InsertAsync(ShipmentDto request);
        Task<Response<bool>> DeleteAsync(ShipmentDto request);
        Task<Response<bool>> UpdateAsync(int id, ShipmentDto request);
        Task<Response<List<ShipmentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ShipmentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByOrderResponseDto>>> GetByOrderAsync(int shipmentsOrderId, int? page, int? size);
        Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ShippingStatus shipmentsShippingStatus, int? page, int? size);
        Task<Response<List<GetShipmentTrackingEventsForShipmentsResponseDto>>> GetShipmentTrackingEventsForShipmentsAsync(int shipmentsId);
        Task<Response<GetShipmentTrackingEventsForShipmentsResponseDto>> GetShipmentTrackingEventsForShipmentsDetailsAsync(int shipmentsId, int shipmentTrackingEventsId);
        Task<Response<List<GetDeliveryExceptionsForShipmentsResponseDto>>> GetDeliveryExceptionsForShipmentsAsync(int shipmentsId);
        Task<Response<GetDeliveryExceptionsForShipmentsResponseDto>> GetDeliveryExceptionsForShipmentsDetailsAsync(int shipmentsId, int deliveryExceptionsId);
        Task<Response<int>> UpdateStatusAsync(int shipmentsId, UpdateStatusRequestDto updateRequest);
    }
}