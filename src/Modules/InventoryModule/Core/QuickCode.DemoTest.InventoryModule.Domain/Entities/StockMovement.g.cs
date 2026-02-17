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

[Table("STOCK_MOVEMENTS")]
public partial class StockMovement : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PRODUCT_ID")]
	public int ProductId { get; set; }
	
	[Column("WAREHOUSE_ID")]
	public int WarehouseId { get; set; }
	
	[Column("MOVEMENT_TYPE")]
	[StringLength(250)]
	public string MovementType { get; set; }
	
	[Column("QUANTITY")]
	public int Quantity { get; set; }
	
	[Column("MOVEMENT_DATE")]
	public DateTime MovementDate { get; set; }
	
	[ForeignKey("WarehouseId")]
	[InverseProperty(nameof(Warehouse.StockMovements))]
	public virtual Warehouse Warehouse { get; set; } = null!;

}

