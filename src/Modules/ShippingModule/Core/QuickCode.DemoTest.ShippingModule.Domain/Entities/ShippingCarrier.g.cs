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

[Table("SHIPPING_CARRIERS")]
public partial class ShippingCarrier : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("TRACKING_URL_FORMAT")]
	[StringLength(1000)]
	public string TrackingUrlFormat { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Shipment.ShippingCarrier))]
	public virtual ICollection<Shipment> Shipments { get; } = new List<Shipment>();

}

