using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.OrderModule.Domain.Entities;
using QuickCode.DemoTest.OrderModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.OrderModule.Application.Dtos.OrderNote;
using QuickCode.DemoTest.OrderModule.Domain.Enums;

namespace QuickCode.DemoTest.OrderModule.Application.Services.OrderNote
{
    public partial interface IOrderNoteService
    {
        Task<Response<OrderNoteDto>> InsertAsync(OrderNoteDto request);
        Task<Response<bool>> DeleteAsync(OrderNoteDto request);
        Task<Response<bool>> UpdateAsync(int id, OrderNoteDto request);
        Task<Response<List<OrderNoteDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<OrderNoteDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByOrderResponseDto>>> GetByOrderAsync(int orderNotesOrderId, int? page, int? size);
    }
}