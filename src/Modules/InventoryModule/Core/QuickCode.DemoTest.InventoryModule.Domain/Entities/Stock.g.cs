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

[Table("STOCKS")]
public partial class Stock : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PRODUCT_ID")]
	public int ProductId { get; set; }
	
	[Column("WAREHOUSE_ID")]
	public int WarehouseId { get; set; }
	
	[Column("QUANTITY")]
	public int Quantity { get; set; }
	
	[Column("LAST_UPDATED")]
	public DateTime LastUpdated { get; set; }
	
	[ForeignKey("WarehouseId")]
	[InverseProperty(nameof(Warehouse.Stocks))]
	public virtual Warehouse Warehouse { get; set; } = null!;

}

