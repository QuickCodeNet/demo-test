using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

public enum ProductVisibility{
	[Description("Visible to all users")]
	Public,
	[Description("Visible only to specific users")]
	Private
}
