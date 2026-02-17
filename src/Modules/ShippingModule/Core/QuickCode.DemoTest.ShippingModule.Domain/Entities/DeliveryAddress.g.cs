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

[Table("DELIVERY_ADDRESSES")]
public partial class DeliveryAddress : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("ADDRESS_LINE_1")]
	[StringLength(250)]
	public string AddressLine1 { get; set; }
	
	[Column("ADDRESS_LINE_2")]
	[StringLength(250)]
	public string AddressLine2 { get; set; }
	
	[Column("CITY")]
	[StringLength(250)]
	public string City { get; set; }
	
	[Column("STATE")]
	[StringLength(250)]
	public string State { get; set; }
	
	[Column("ZIP_CODE")]
	[StringLength(250)]
	public string ZipCode { get; set; }
	
	[Column("COUNTRY")]
	[StringLength(250)]
	public string Country { get; set; }
	
	[InverseProperty(nameof(Shipment.DeliveryAddress))]
	public virtual ICollection<Shipment> Shipments { get; } = new List<Shipment>();

}

