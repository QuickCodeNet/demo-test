using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoTest.OrderModule.Domain;
using QuickCode.DemoTest.Common;
using QuickCode.DemoTest.Common.Auditing;

namespace QuickCode.DemoTest.OrderModule.Domain.Entities;

[Table("PAYMENT_METHODS")]
public partial class PaymentMethod : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("CARD_NUMBER")]
	[StringLength(250)]
	public string CardNumber { get; set; }
	
	[Column("EXPIRY_DATE")]
	public DateTime ExpiryDate { get; set; }
	
	[Column("CVV")]
	[StringLength(250)]
	public string Cvv { get; set; }
	
	[Column("PAYMENT_TYPE")]
	[StringLength(250)]
	public string PaymentType { get; set; }
	
	[InverseProperty(nameof(Order.PaymentMethod))]
	public virtual ICollection<Order> Orders { get; } = new List<Order>();

}

