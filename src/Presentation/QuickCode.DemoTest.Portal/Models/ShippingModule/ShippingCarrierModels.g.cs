using QuickCode.DemoTest.Common.Nswag.Clients.ShippingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoTest.Portal.Helpers;

namespace QuickCode.DemoTest.Portal.Models.ShippingModule
{
    public class ShippingCarrierData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public ShippingCarrierDto SelectedItem { get; set; }
        public List<ShippingCarrierDto> List { get; set; }
    }

    public static partial class ShippingCarrierExtensions
    {
        public static string GetKey(this ShippingCarrierDto dto)
        {
            return $"{dto.Id}";
        }
    }
}