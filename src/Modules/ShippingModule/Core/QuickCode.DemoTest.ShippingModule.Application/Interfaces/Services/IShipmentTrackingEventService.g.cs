using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.ShippingModule.Domain.Entities;
using QuickCode.DemoTest.ShippingModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.ShipmentTrackingEvent;
using QuickCode.DemoTest.ShippingModule.Domain.Enums;

namespace QuickCode.DemoTest.ShippingModule.Application.Services.ShipmentTrackingEvent
{
    public partial interface IShipmentTrackingEventService
    {
        Task<Response<ShipmentTrackingEventDto>> InsertAsync(ShipmentTrackingEventDto request);
        Task<Response<bool>> DeleteAsync(ShipmentTrackingEventDto request);
        Task<Response<bool>> UpdateAsync(int id, ShipmentTrackingEventDto request);
        Task<Response<List<ShipmentTrackingEventDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ShipmentTrackingEventDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByShipmentResponseDto>>> GetByShipmentAsync(int shipmentTrackingEventsShipmentId, int? page, int? size);
    }
}