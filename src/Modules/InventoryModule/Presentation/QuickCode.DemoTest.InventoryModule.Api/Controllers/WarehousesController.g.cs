using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.Common.Controllers;
using QuickCode.DemoTest.InventoryModule.Application.Dtos.Warehouse;
using QuickCode.DemoTest.InventoryModule.Application.Services.Warehouse;

namespace QuickCode.DemoTest.InventoryModule.Api.Controllers
{
    public partial class WarehousesController : QuickCodeBaseApiController
    {
        private readonly IWarehouseService service;
        private readonly ILogger<WarehousesController> logger;
        private readonly IServiceProvider serviceProvider;
        public WarehousesController(IWarehouseService service, IServiceProvider serviceProvider, ILogger<WarehousesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<WarehouseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Warehouse", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Warehouse") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Warehouse", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WarehouseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(WarehouseDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Warehouse") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, WarehouseDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Warehouse", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Warehouse", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active/{warehousesIsActive:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetActiveResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveAsync(bool warehousesIsActive, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetActiveAsync(warehousesIsActive, page, size);
            if (HandleResponseError(response, logger, "Warehouse", $"WarehousesIsActive: '{warehousesIsActive}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{warehouseId}/stock")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetStocksForWarehousesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetStocksForWarehousesAsync(int warehousesId)
        {
            var response = await service.GetStocksForWarehousesAsync(warehousesId);
            if (HandleResponseError(response, logger, "Warehouse", $"WarehousesId: '{warehousesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{warehouseId}/stock/{stockId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetStocksForWarehousesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetStocksForWarehousesDetailsAsync(int warehousesId, int stocksId)
        {
            var response = await service.GetStocksForWarehousesDetailsAsync(warehousesId, stocksId);
            if (HandleResponseError(response, logger, "Warehouse", $"WarehousesId: '{warehousesId}', StocksId: '{stocksId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{warehouseId}/stock-movement")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetStockMovementsForWarehousesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetStockMovementsForWarehousesAsync(int warehousesId)
        {
            var response = await service.GetStockMovementsForWarehousesAsync(warehousesId);
            if (HandleResponseError(response, logger, "Warehouse", $"WarehousesId: '{warehousesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{warehouseId}/stock-movement/{stockMovementId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetStockMovementsForWarehousesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetStockMovementsForWarehousesDetailsAsync(int warehousesId, int stockMovementsId)
        {
            var response = await service.GetStockMovementsForWarehousesDetailsAsync(warehousesId, stockMovementsId);
            if (HandleResponseError(response, logger, "Warehouse", $"WarehousesId: '{warehousesId}', StockMovementsId: '{stockMovementsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{warehouseId}/reorder-point")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetReorderPointsForWarehousesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetReorderPointsForWarehousesAsync(int warehousesId)
        {
            var response = await service.GetReorderPointsForWarehousesAsync(warehousesId);
            if (HandleResponseError(response, logger, "Warehouse", $"WarehousesId: '{warehousesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{warehouseId}/reorder-point/{reorderPointId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetReorderPointsForWarehousesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetReorderPointsForWarehousesDetailsAsync(int warehousesId, int reorderPointsId)
        {
            var response = await service.GetReorderPointsForWarehousesDetailsAsync(warehousesId, reorderPointsId);
            if (HandleResponseError(response, logger, "Warehouse", $"WarehousesId: '{warehousesId}', ReorderPointsId: '{reorderPointsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{warehouseId}/inventory-adjustment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetInventoryAdjustmentsForWarehousesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetInventoryAdjustmentsForWarehousesAsync(int warehousesId)
        {
            var response = await service.GetInventoryAdjustmentsForWarehousesAsync(warehousesId);
            if (HandleResponseError(response, logger, "Warehouse", $"WarehousesId: '{warehousesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{warehouseId}/inventory-adjustment/{inventoryAdjustmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetInventoryAdjustmentsForWarehousesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetInventoryAdjustmentsForWarehousesDetailsAsync(int warehousesId, int inventoryAdjustmentsId)
        {
            var response = await service.GetInventoryAdjustmentsForWarehousesDetailsAsync(warehousesId, inventoryAdjustmentsId);
            if (HandleResponseError(response, logger, "Warehouse", $"WarehousesId: '{warehousesId}', InventoryAdjustmentsId: '{inventoryAdjustmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}