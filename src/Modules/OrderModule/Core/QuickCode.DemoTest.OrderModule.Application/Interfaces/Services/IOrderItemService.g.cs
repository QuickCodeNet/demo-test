using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.OrderModule.Domain.Entities;
using QuickCode.DemoTest.OrderModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.OrderModule.Application.Dtos.OrderItem;
using QuickCode.DemoTest.OrderModule.Domain.Enums;

namespace QuickCode.DemoTest.OrderModule.Application.Services.OrderItem
{
    public partial interface IOrderItemService
    {
        Task<Response<OrderItemDto>> InsertAsync(OrderItemDto request);
        Task<Response<bool>> DeleteAsync(OrderItemDto request);
        Task<Response<bool>> UpdateAsync(int id, OrderItemDto request);
        Task<Response<List<OrderItemDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<OrderItemDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByOrderResponseDto>>> GetByOrderAsync(int orderItemsOrderId, int? page, int? size);
    }
}