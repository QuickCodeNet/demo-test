using QuickCode.DemoTest.Common.Nswag.Clients.OrderModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoTest.Portal.Helpers;

namespace QuickCode.DemoTest.Portal.Models.OrderModule
{
    public class PaymentMethodData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public PaymentMethodDto SelectedItem { get; set; }
        public List<PaymentMethodDto> List { get; set; }
    }

    public static partial class PaymentMethodExtensions
    {
        public static string GetKey(this PaymentMethodDto dto)
        {
            return $"{dto.Id}";
        }
    }
}