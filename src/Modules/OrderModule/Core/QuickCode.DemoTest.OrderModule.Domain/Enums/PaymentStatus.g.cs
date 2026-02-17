using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoTest.OrderModule.Domain.Enums;

public enum PaymentStatus{
	[Description("Payment is awaiting confirmation")]
	Pending,
	[Description("Payment has been received")]
	Paid,
	[Description("Payment has failed")]
	Failed,
	[Description("Payment has been refunded")]
	Refunded
}
