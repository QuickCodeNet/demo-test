using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.Common.Controllers;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.Shipment;
using QuickCode.DemoTest.ShippingModule.Application.Services.Shipment;
using QuickCode.DemoTest.ShippingModule.Domain.Enums;

namespace QuickCode.DemoTest.ShippingModule.Api.Controllers
{
    public partial class ShipmentsController : QuickCodeBaseApiController
    {
        private readonly IShipmentService service;
        private readonly ILogger<ShipmentsController> logger;
        private readonly IServiceProvider serviceProvider;
        public ShipmentsController(IShipmentService service, IServiceProvider serviceProvider, ILogger<ShipmentsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ShipmentDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Shipment", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Shipment") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShipmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Shipment", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ShipmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(ShipmentDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Shipment") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, ShipmentDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Shipment", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await service.DeleteItemAsync(id);
            if (HandleResponseError(response, logger, "Shipment", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-order/{shipmentsOrderId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByOrderResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByOrderAsync(int shipmentsOrderId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByOrderAsync(shipmentsOrderId, page, size);
            if (HandleResponseError(response, logger, "Shipment", $"ShipmentsOrderId: '{shipmentsOrderId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-status/{shipmentsShippingStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByStatusResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByStatusAsync(ShippingStatus shipmentsShippingStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByStatusAsync(shipmentsShippingStatus, page, size);
            if (HandleResponseError(response, logger, "Shipment", $"ShipmentsShippingStatus: '{shipmentsShippingStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{shipmentId}/shipment-tracking-event")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetShipmentTrackingEventsForShipmentsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetShipmentTrackingEventsForShipmentsAsync(int shipmentsId)
        {
            var response = await service.GetShipmentTrackingEventsForShipmentsAsync(shipmentsId);
            if (HandleResponseError(response, logger, "Shipment", $"ShipmentsId: '{shipmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{shipmentId}/shipment-tracking-event/{shipmentTrackingEventId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetShipmentTrackingEventsForShipmentsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetShipmentTrackingEventsForShipmentsDetailsAsync(int shipmentsId, int shipmentTrackingEventsId)
        {
            var response = await service.GetShipmentTrackingEventsForShipmentsDetailsAsync(shipmentsId, shipmentTrackingEventsId);
            if (HandleResponseError(response, logger, "Shipment", $"ShipmentsId: '{shipmentsId}', ShipmentTrackingEventsId: '{shipmentTrackingEventsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{shipmentId}/delivery-exception")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetDeliveryExceptionsForShipmentsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetDeliveryExceptionsForShipmentsAsync(int shipmentsId)
        {
            var response = await service.GetDeliveryExceptionsForShipmentsAsync(shipmentsId);
            if (HandleResponseError(response, logger, "Shipment", $"ShipmentsId: '{shipmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{shipmentId}/delivery-exception/{deliveryExceptionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDeliveryExceptionsForShipmentsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetDeliveryExceptionsForShipmentsDetailsAsync(int shipmentsId, int deliveryExceptionsId)
        {
            var response = await service.GetDeliveryExceptionsForShipmentsDetailsAsync(shipmentsId, deliveryExceptionsId);
            if (HandleResponseError(response, logger, "Shipment", $"ShipmentsId: '{shipmentsId}', DeliveryExceptionsId: '{deliveryExceptionsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-status/{shipmentsId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateStatusAsync(int shipmentsId, [FromBody] UpdateStatusRequestDto updateRequest)
        {
            var response = await service.UpdateStatusAsync(shipmentsId, updateRequest);
            if (HandleResponseError(response, logger, "Shipment", $"ShipmentsId: '{shipmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}