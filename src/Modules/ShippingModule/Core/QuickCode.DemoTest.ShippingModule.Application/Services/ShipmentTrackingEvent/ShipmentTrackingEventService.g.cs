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
    public partial class ShipmentTrackingEventService : IShipmentTrackingEventService
    {
        private readonly ILogger<ShipmentTrackingEventService> _logger;
        private readonly IShipmentTrackingEventRepository _repository;
        public ShipmentTrackingEventService(ILogger<ShipmentTrackingEventService> logger, IShipmentTrackingEventRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ShipmentTrackingEventDto>> InsertAsync(ShipmentTrackingEventDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ShipmentTrackingEventDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ShipmentTrackingEventDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ShipmentTrackingEventDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ShipmentTrackingEventDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByShipmentResponseDto>>> GetByShipmentAsync(int shipmentTrackingEventsShipmentId, int? page, int? size)
        {
            var returnValue = await _repository.GetByShipmentAsync(shipmentTrackingEventsShipmentId, page, size);
            return returnValue.ToResponse();
        }
    }
}