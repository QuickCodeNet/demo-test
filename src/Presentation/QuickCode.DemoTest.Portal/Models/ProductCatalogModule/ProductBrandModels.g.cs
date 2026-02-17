using QuickCode.DemoTest.Common.Nswag.Clients.ProductCatalogModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoTest.Portal.Helpers;

namespace QuickCode.DemoTest.Portal.Models.ProductCatalogModule
{
    public class ProductBrandData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public ProductBrandDto SelectedItem { get; set; }
        public List<ProductBrandDto> List { get; set; }
    }

    public static partial class ProductBrandExtensions
    {
        public static string GetKey(this ProductBrandDto dto)
        {
            return $"{dto.Id}";
        }
    }
}