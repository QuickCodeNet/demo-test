using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoTest.Common.Controllers;
using QuickCode.DemoTest.ProductCatalogModule.Application.Dtos.Product;
using QuickCode.DemoTest.ProductCatalogModule.Application.Services.Product;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoTest.ProductCatalogModule.Api.Controllers
{
    public partial class ProductsController : QuickCodeBaseApiController
    {
        private readonly IProductService service;
        private readonly ILogger<ProductsController> logger;
        private readonly IServiceProvider serviceProvider;
        public ProductsController(IProductService service, IServiceProvider serviceProvider, ILogger<ProductsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Product", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Product") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Product", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(ProductDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Product") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, ProductDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Product", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Product", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active/{productsStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetActiveResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveAsync(ProductStatus productsStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetActiveAsync(productsStatus, page, size);
            if (HandleResponseError(response, logger, "Product", $"ProductsStatus: '{productsStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("search-by-name/{productsName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SearchByNameResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SearchByNameAsync(string productsName, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.SearchByNameAsync(productsName, page, size);
            if (HandleResponseError(response, logger, "Product", $"ProductsName: '{productsName}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-category/{productsCategoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCategoryResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCategoryAsync(int productsCategoryId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCategoryAsync(productsCategoryId, page, size);
            if (HandleResponseError(response, logger, "Product", $"ProductsCategoryId: '{productsCategoryId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-price-range/{productsPrice:decimal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByPriceRangeResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByPriceRangeAsync(decimal productsPrice, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByPriceRangeAsync(productsPrice, page, size);
            if (HandleResponseError(response, logger, "Product", $"ProductsPrice: '{productsPrice}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-newest")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetNewestResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetNewestAsync(int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetNewestAsync(page, size);
            if (HandleResponseError(response, logger, "Product", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{productId}/product-image")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetProductImagesForProductsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductImagesForProductsAsync(int productsId)
        {
            var response = await service.GetProductImagesForProductsAsync(productsId);
            if (HandleResponseError(response, logger, "Product", $"ProductsId: '{productsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{productId}/product-image/{productImageId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductImagesForProductsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductImagesForProductsDetailsAsync(int productsId, int productImagesId)
        {
            var response = await service.GetProductImagesForProductsDetailsAsync(productsId, productImagesId);
            if (HandleResponseError(response, logger, "Product", $"ProductsId: '{productsId}', ProductImagesId: '{productImagesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{productId}/product-review")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetProductReviewsForProductsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductReviewsForProductsAsync(int productsId)
        {
            var response = await service.GetProductReviewsForProductsAsync(productsId);
            if (HandleResponseError(response, logger, "Product", $"ProductsId: '{productsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{productId}/product-review/{productReviewId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductReviewsForProductsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductReviewsForProductsDetailsAsync(int productsId, int productReviewsId)
        {
            var response = await service.GetProductReviewsForProductsDetailsAsync(productsId, productReviewsId);
            if (HandleResponseError(response, logger, "Product", $"ProductsId: '{productsId}', ProductReviewsId: '{productReviewsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{productId}/product-specification")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetProductSpecificationsForProductsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductSpecificationsForProductsAsync(int productsId)
        {
            var response = await service.GetProductSpecificationsForProductsAsync(productsId);
            if (HandleResponseError(response, logger, "Product", $"ProductsId: '{productsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{productId}/product-specification/{productSpecificationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductSpecificationsForProductsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductSpecificationsForProductsDetailsAsync(int productsId, int productSpecificationsId)
        {
            var response = await service.GetProductSpecificationsForProductsDetailsAsync(productsId, productSpecificationsId);
            if (HandleResponseError(response, logger, "Product", $"ProductsId: '{productsId}', ProductSpecificationsId: '{productSpecificationsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-price/{productsId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdatePriceAsync(int productsId, [FromBody] UpdatePriceRequestDto updateRequest)
        {
            var response = await service.UpdatePriceAsync(productsId, updateRequest);
            if (HandleResponseError(response, logger, "Product", $"ProductsId: '{productsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}