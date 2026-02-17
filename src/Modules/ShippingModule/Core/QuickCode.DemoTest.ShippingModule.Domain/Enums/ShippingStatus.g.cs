using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoTest.ShippingModule.Domain.Enums;

public enum ShippingStatus{
	[Description("Shipment is awaiting processing")]
	Pending,
	[Description("Shipment is being processed")]
	Processing,
	[Description("Shipment has been shipped")]
	Shipped,
	[Description("Shipment is in transit")]
	InTransit,
	[Description("Shipment has been delivered")]
	Delivered,
	[Description("Shipment has encountered an exception")]
	Exception
}
