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
    public partial interface IOrderService
    {
        Task<Response<OrderDto>> InsertAsync(OrderDto request);
        Task<Response<bool>> DeleteAsync(OrderDto request);
        Task<Response<bool>> UpdateAsync(int id, OrderDto request);
        Task<Response<List<OrderDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<OrderDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerResponseDto>>> GetByCustomerAsync(int ordersCustomerId, int? page, int? size);
        Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(OrderStatus ordersOrderStatus, int? page, int? size);
        Task<Response<List<GetPendingResponseDto>>> GetPendingAsync(OrderStatus ordersOrderStatus, int? page, int? size);
        Task<Response<GetDailyRevenueResponseDto>> GetDailyRevenueAsync();
        Task<Response<List<GetOrderItemsForOrdersResponseDto>>> GetOrderItemsForOrdersAsync(int ordersId);
        Task<Response<GetOrderItemsForOrdersResponseDto>> GetOrderItemsForOrdersDetailsAsync(int ordersId, int orderItemsId);
        Task<Response<List<GetOrderNotesForOrdersResponseDto>>> GetOrderNotesForOrdersAsync(int ordersId);
        Task<Response<GetOrderNotesForOrdersResponseDto>> GetOrderNotesForOrdersDetailsAsync(int ordersId, int orderNotesId);
        Task<Response<int>> UpdateStatusAsync(int ordersId, UpdateStatusRequestDto updateRequest);
    }
}