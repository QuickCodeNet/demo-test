using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.Common.Controllers;
using QuickCode.DemoTest.ShippingModule.Application.Dtos.DeliveryAddress;
using QuickCode.DemoTest.ShippingModule.Application.Services.DeliveryAddress;
using QuickCode.DemoTest.ShippingModule.Domain.Enums;

namespace QuickCode.DemoTest.ShippingModule.Api.Controllers
{
    public partial class DeliveryAddressesController : QuickCodeBaseApiController
    {
        private readonly IDeliveryAddressService service;
        private readonly ILogger<DeliveryAddressesController> logger;
        private readonly IServiceProvider serviceProvider;
        public DeliveryAddressesController(IDeliveryAddressService service, IServiceProvider serviceProvider, ILogger<DeliveryAddressesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DeliveryAddressDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "DeliveryAddress", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "DeliveryAddress") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeliveryAddressDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "DeliveryAddress", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DeliveryAddressDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(DeliveryAddressDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "DeliveryAddress") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, DeliveryAddressDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "DeliveryAddress", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "DeliveryAddress", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer/{deliveryAddressesCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCustomerResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerAsync(int deliveryAddressesCustomerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCustomerAsync(deliveryAddressesCustomerId, page, size);
            if (HandleResponseError(response, logger, "DeliveryAddress", $"DeliveryAddressesCustomerId: '{deliveryAddressesCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{deliveryAddressId}/shipment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetShipmentsForDeliveryAddressesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetShipmentsForDeliveryAddressesAsync(int deliveryAddressesId)
        {
            var response = await service.GetShipmentsForDeliveryAddressesAsync(deliveryAddressesId);
            if (HandleResponseError(response, logger, "DeliveryAddress", $"DeliveryAddressesId: '{deliveryAddressesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{deliveryAddressId}/shipment/{shipmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetShipmentsForDeliveryAddressesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetShipmentsForDeliveryAddressesDetailsAsync(int deliveryAddressesId, int shipmentsId)
        {
            var response = await service.GetShipmentsForDeliveryAddressesDetailsAsync(deliveryAddressesId, shipmentsId);
            if (HandleResponseError(response, logger, "DeliveryAddress", $"DeliveryAddressesId: '{deliveryAddressesId}', ShipmentsId: '{shipmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}