using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.Common.Controllers;
using QuickCode.DemoTest.OrderModule.Application.Dtos.Order;
using QuickCode.DemoTest.OrderModule.Application.Services.Order;
using QuickCode.DemoTest.OrderModule.Domain.Enums;

namespace QuickCode.DemoTest.OrderModule.Api.Controllers
{
    public partial class OrdersController : QuickCodeBaseApiController
    {
        private readonly IOrderService service;
        private readonly ILogger<OrdersController> logger;
        private readonly IServiceProvider serviceProvider;
        public OrdersController(IOrderService service, IServiceProvider serviceProvider, ILogger<OrdersController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Order", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Order") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Order", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(OrderDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Order") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, OrderDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Order", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Order", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer/{ordersCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCustomerResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerAsync(int ordersCustomerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCustomerAsync(ordersCustomerId, page, size);
            if (HandleResponseError(response, logger, "Order", $"OrdersCustomerId: '{ordersCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-status/{ordersOrderStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByStatusResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByStatusAsync(OrderStatus ordersOrderStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByStatusAsync(ordersOrderStatus, page, size);
            if (HandleResponseError(response, logger, "Order", $"OrdersOrderStatus: '{ordersOrderStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-pending/{ordersOrderStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetPendingResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPendingAsync(OrderStatus ordersOrderStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetPendingAsync(ordersOrderStatus, page, size);
            if (HandleResponseError(response, logger, "Order", $"OrdersOrderStatus: '{ordersOrderStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-daily-revenue")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDailyRevenueResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetDailyRevenueAsync()
        {
            var response = await service.GetDailyRevenueAsync();
            if (HandleResponseError(response, logger, "Order", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{orderId}/order-item")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetOrderItemsForOrdersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetOrderItemsForOrdersAsync(int ordersId)
        {
            var response = await service.GetOrderItemsForOrdersAsync(ordersId);
            if (HandleResponseError(response, logger, "Order", $"OrdersId: '{ordersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{orderId}/order-item/{orderItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderItemsForOrdersResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetOrderItemsForOrdersDetailsAsync(int ordersId, int orderItemsId)
        {
            var response = await service.GetOrderItemsForOrdersDetailsAsync(ordersId, orderItemsId);
            if (HandleResponseError(response, logger, "Order", $"OrdersId: '{ordersId}', OrderItemsId: '{orderItemsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{orderId}/order-note")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetOrderNotesForOrdersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetOrderNotesForOrdersAsync(int ordersId)
        {
            var response = await service.GetOrderNotesForOrdersAsync(ordersId);
            if (HandleResponseError(response, logger, "Order", $"OrdersId: '{ordersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{orderId}/order-note/{orderNoteId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderNotesForOrdersResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetOrderNotesForOrdersDetailsAsync(int ordersId, int orderNotesId)
        {
            var response = await service.GetOrderNotesForOrdersDetailsAsync(ordersId, orderNotesId);
            if (HandleResponseError(response, logger, "Order", $"OrdersId: '{ordersId}', OrderNotesId: '{orderNotesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-status/{ordersId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateStatusAsync(int ordersId, [FromBody] UpdateStatusRequestDto updateRequest)
        {
            var response = await service.UpdateStatusAsync(ordersId, updateRequest);
            if (HandleResponseError(response, logger, "Order", $"OrdersId: '{ordersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}