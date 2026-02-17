using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

public enum ProductStatus{
	[Description("Product is available for sale")]
	Active,
	[Description("Product is not available for sale")]
	Inactive,
	[Description("Product is no longer sold")]
	Discontinued
}
