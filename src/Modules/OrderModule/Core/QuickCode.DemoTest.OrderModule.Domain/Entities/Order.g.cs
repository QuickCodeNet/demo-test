using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoTest.OrderModule.Domain;
using QuickCode.DemoTest.Common;
using QuickCode.DemoTest.Common.Auditing;
using QuickCode.DemoTest.OrderModule.Domain.Enums;

namespace QuickCode.DemoTest.OrderModule.Domain.Entities;

[Table("ORDERS")]
public partial class Order : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("ORDER_DATE")]
	public DateTime OrderDate { get; set; }
	
	[Column("TOTAL_AMOUNT")]
	[Precision(18,2)]
	public decimal TotalAmount { get; set; }
	
	[Column("SHIPPING_ADDRESS_ID")]
	public int ShippingAddressId { get; set; }
	
	[Column("BILLING_ADDRESS_ID")]
	public int BillingAddressId { get; set; }
	
	[Column("ORDER_STATUS", TypeName = "nvarchar(250)")]
	public OrderStatus OrderStatus { get; set; }
	
	[Column("PAYMENT_STATUS", TypeName = "nvarchar(250)")]
	public PaymentStatus PaymentStatus { get; set; }
	
	[Column("PAYMENT_METHOD_ID")]
	public int PaymentMethodId { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(OrderItem.Order))]
	public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();


	[InverseProperty(nameof(OrderNote.Order))]
	public virtual ICollection<OrderNote> OrderNotes { get; } = new List<OrderNote>();


	[ForeignKey("ShippingAddressId")]
	[InverseProperty(nameof(ShippingAddress.Orders))]
	public virtual ShippingAddress ShippingAddress { get; set; } = null!;


	[ForeignKey("BillingAddressId")]
	[InverseProperty(nameof(BillingAddress.Orders))]
	public virtual BillingAddress BillingAddress { get; set; } = null!;


	[ForeignKey("PaymentMethodId")]
	[InverseProperty(nameof(PaymentMethod.Orders))]
	public virtual PaymentMethod PaymentMethod { get; set; } = null!;

}

