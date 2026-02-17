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

[Table("SHIPMENT_TRACKING_EVENTS")]
public partial class ShipmentTrackingEvent : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("SHIPMENT_ID")]
	public int ShipmentId { get; set; }
	
	[Column("EVENT_DATE")]
	public DateTime EventDate { get; set; }
	
	[Column("EVENT_LOCATION")]
	[StringLength(250)]
	public string EventLocation { get; set; }
	
	[Column("EVENT_DESCRIPTION")]
	[StringLength(250)]
	public string EventDescription { get; set; }
	
	[ForeignKey("ShipmentId")]
	[InverseProperty(nameof(Shipment.ShipmentTrackingEvents))]
	public virtual Shipment Shipment { get; set; } = null!;

}

