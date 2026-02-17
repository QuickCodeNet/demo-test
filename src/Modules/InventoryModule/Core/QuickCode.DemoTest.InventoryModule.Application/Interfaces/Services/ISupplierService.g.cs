using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoTest.Common.Models;
using QuickCode.DemoTest.InventoryModule.Domain.Entities;
using QuickCode.DemoTest.InventoryModule.Application.Interfaces.Repositories;
using QuickCode.DemoTest.InventoryModule.Application.Dtos.Supplier;

namespace QuickCode.DemoTest.InventoryModule.Application.Services.Supplier
{
    public partial interface ISupplierService
    {
        Task<Response<SupplierDto>> InsertAsync(SupplierDto request);
        Task<Response<bool>> DeleteAsync(SupplierDto request);
        Task<Response<bool>> UpdateAsync(int id, SupplierDto request);
        Task<Response<List<SupplierDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<SupplierDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string suppliersName, int? page, int? size);
    }
}