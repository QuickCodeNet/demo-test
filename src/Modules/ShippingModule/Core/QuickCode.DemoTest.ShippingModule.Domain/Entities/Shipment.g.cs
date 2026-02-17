using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoTest.ShippingModule.Domain;
using QuickCode.DemoTest.Common;
using QuickCode.DemoTest.Common.Auditing;
using QuickCode.DemoTest.ShippingModule.Domain.Enums;

namespace QuickCode.DemoTest.ShippingModule.Domain.Entities;

[Table("SHIPMENTS")]
public partial class Shipment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ORDER_ID")]
	public int OrderId { get; set; }
	
	[Column("SHIPPING_CARRIER_ID")]
	public int ShippingCarrierId { get; set; }
	
	[Column("TRACKING_NUMBER")]
	[StringLength(250)]
	public string TrackingNumber { get; set; }
	
	[Column("SHIPPING_DATE")]
	public DateTime ShippingDate { get; set; }
	
	[Column("ESTIMATED_DELIVERY_DATE")]
	public DateTime EstimatedDeliveryDate { get; set; }
	
	[Column("ACTUAL_DELIVERY_DATE")]
	public DateTime ActualDeliveryDate { get; set; }
	
	[Column("SHIPPING_STATUS", TypeName = "nvarchar(250)")]
	public ShippingStatus ShippingStatus { get; set; }
	
	[Column("SHIPPING_COST")]
	[Precision(18,2)]
	public decimal ShippingCost { get; set; }
	
	[Column("DELIVERY_ADDRESS_ID")]
	public int DeliveryAddressId { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(ShipmentTrackingEvent.Shipment))]
	public virtual ICollection<ShipmentTrackingEvent> ShipmentTrackingEvents { get; } = new List<ShipmentTrackingEvent>();


	[InverseProperty(nameof(DeliveryException.Shipment))]
	public virtual ICollection<DeliveryException> DeliveryExceptions { get; } = new List<DeliveryException>();


	[ForeignKey("ShippingCarrierId")]
	[InverseProperty(nameof(ShippingCarrier.Shipments))]
	public virtual ShippingCarrier ShippingCarrier { get; set; } = null!;


	[ForeignKey("DeliveryAddressId")]
	[InverseProperty(nameof(DeliveryAddress.Shipments))]
	public virtual DeliveryAddress DeliveryAddress { get; set; } = null!;

}

