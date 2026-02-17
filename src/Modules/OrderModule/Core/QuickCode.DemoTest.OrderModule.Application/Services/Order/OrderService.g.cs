using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.OrderModule.Domain.Entities;
using QuickCode.DemoTest.OrderModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.OrderModule.Application.Dtos.Order;
using QuickCode.DemoTest.OrderModule.Domain.Enums;

namespace QuickCode.DemoTest.OrderModule.Application.Services.Order
{
    public partial class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepository _repository;
        public OrderService(ILogger<OrderService> logger, IOrderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<OrderDto>> InsertAsync(OrderDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(OrderDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, OrderDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<OrderDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<OrderDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCustomerResponseDto>>> GetByCustomerAsync(int ordersCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerAsync(ordersCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(OrderStatus ordersOrderStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetByStatusAsync(ordersOrderStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetPendingResponseDto>>> GetPendingAsync(OrderStatus ordersOrderStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetPendingAsync(ordersOrderStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetDailyRevenueResponseDto>> GetDailyRevenueAsync()
        {
            var returnValue = await _repository.GetDailyRevenueAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetOrderItemsForOrdersResponseDto>>> GetOrderItemsForOrdersAsync(int ordersId)
        {
            var returnValue = await _repository.GetOrderItemsForOrdersAsync(ordersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetOrderItemsForOrdersResponseDto>> GetOrderItemsForOrdersDetailsAsync(int ordersId, int orderItemsId)
        {
            var returnValue = await _repository.GetOrderItemsForOrdersDetailsAsync(ordersId, orderItemsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetOrderNotesForOrdersResponseDto>>> GetOrderNotesForOrdersAsync(int ordersId)
        {
            var returnValue = await _repository.GetOrderNotesForOrdersAsync(ordersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetOrderNotesForOrdersResponseDto>> GetOrderNotesForOrdersDetailsAsync(int ordersId, int orderNotesId)
        {
            var returnValue = await _repository.GetOrderNotesForOrdersDetailsAsync(ordersId, orderNotesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateStatusAsync(int ordersId, UpdateStatusRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateStatusAsync(ordersId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}