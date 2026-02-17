using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoTest.InventoryModule.Domain;
using QuickCode.DemoTest.Common;
using QuickCode.DemoTest.Common.Auditing;

namespace QuickCode.DemoTest.InventoryModule.Domain.Entities;

[Table("REORDER_POINTS")]
public partial class ReorderPoint : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PRODUCT_ID")]
	public int ProductId { get; set; }
	
	[Column("WAREHOUSE_ID")]
	public int WarehouseId { get; set; }
	
	[Column("REORDER_QUANTITY")]
	public int ReorderQuantity { get; set; }
	
	[Column("MINIMUM_STOCK_LEVEL")]
	public int MinimumStockLevel { get; set; }
	
	[ForeignKey("WarehouseId")]
	[InverseProperty(nameof(Warehouse.ReorderPoints))]
	public virtual Warehouse Warehouse { get; set; } = null!;

}

