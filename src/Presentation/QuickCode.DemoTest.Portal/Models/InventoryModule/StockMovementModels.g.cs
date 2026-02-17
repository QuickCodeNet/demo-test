using QuickCode.DemoTest.Common.Nswag.Clients.InventoryModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoTest.Portal.Helpers;

namespace QuickCode.DemoTest.Portal.Models.InventoryModule
{
    public class StockMovementData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public StockMovementDto SelectedItem { get; set; }
        public List<StockMovementDto> List { get; set; }
    }

    public static partial class StockMovementExtensions
    {
        public static string GetKey(this StockMovementDto dto)
        {
            return $"{dto.Id}";
        }
    }
}