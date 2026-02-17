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

[Table("SHIPPING_RATES")]
public partial class ShippingRate : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CARRIER_ID")]
	public int CarrierId { get; set; }
	
	[Column("DESTINATION_ZIP_CODE")]
	[StringLength(250)]
	public string DestinationZipCode { get; set; }
	
	[Column("WEIGHT_FROM")]
	public decimal WeightFrom { get; set; }
	
	[Column("WEIGHT_TO")]
	public decimal WeightTo { get; set; }
	
	[Column("RATE")]
	[Precision(18,2)]
	public decimal Rate { get; set; }
	}

