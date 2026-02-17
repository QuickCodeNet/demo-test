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

[Table("INVENTORY_ADJUSTMENTS")]
public partial class InventoryAdjustment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PRODUCT_ID")]
	public int ProductId { get; set; }
	
	[Column("WAREHOUSE_ID")]
	public int WarehouseId { get; set; }
	
	[Column("ADJUSTMENT_QUANTITY")]
	public int AdjustmentQuantity { get; set; }
	
	[Column("ADJUSTMENT_REASON")]
	[StringLength(250)]
	public string AdjustmentReason { get; set; }
	
	[Column("ADJUSTMENT_DATE")]
	public DateTime AdjustmentDate { get; set; }
	
	[ForeignKey("WarehouseId")]
	[InverseProperty(nameof(Warehouse.InventoryAdjustments))]
	public virtual Warehouse Warehouse { get; set; } = null!;

}

