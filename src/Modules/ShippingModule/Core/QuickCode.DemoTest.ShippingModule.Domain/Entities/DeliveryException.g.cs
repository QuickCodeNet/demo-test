using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoTest.ShippingModule.Domain;
using QuickCode.DemoTest.Common;
using QuickCode.DemoTest.Common.Auditing;

namespace QuickCode.DemoTest.ShippingModule.Domain.Entities;

[Table("DELIVERY_EXCEPTIONS")]
public partial class DeliveryException : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("SHIPMENT_ID")]
	public int ShipmentId { get; set; }
	
	[Column("EXCEPTION_DATE")]
	public DateTime ExceptionDate { get; set; }
	
	[Column("EXCEPTION_REASON")]
	[StringLength(250)]
	public string ExceptionReason { get; set; }
	
	[ForeignKey("ShipmentId")]
	[InverseProperty(nameof(Shipment.DeliveryExceptions))]
	public virtual Shipment Shipment { get; set; } = null!;

}

