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

[Table("WAREHOUSES")]
public partial class Warehouse : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("LOCATION")]
	[StringLength(250)]
	public string Location { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Stock.Warehouse))]
	public virtual ICollection<Stock> Stocks { get; } = new List<Stock>();


	[InverseProperty(nameof(StockMovement.Warehouse))]
	public virtual ICollection<StockMovement> StockMovements { get; } = new List<StockMovement>();


	[InverseProperty(nameof(ReorderPoint.Warehouse))]
	public virtual ICollection<ReorderPoint> ReorderPoints { get; } = new List<ReorderPoint>();


	[InverseProperty(nameof(InventoryAdjustment.Warehouse))]
	public virtual ICollection<InventoryAdjustment> InventoryAdjustments { get; } = new List<InventoryAdjustment>();

}

