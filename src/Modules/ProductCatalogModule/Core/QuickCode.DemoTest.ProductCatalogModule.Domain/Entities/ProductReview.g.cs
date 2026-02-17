using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoTest.ProductCatalogModule.Domain;
using QuickCode.DemoTest.Common;
using QuickCode.DemoTest.Common.Auditing;

namespace QuickCode.DemoTest.ProductCatalogModule.Domain.Entities;

[Table("PRODUCT_REVIEWS")]
public partial class ProductReview : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PRODUCT_ID")]
	public int ProductId { get; set; }
	
	[Column("USER_ID")]
	public int UserId { get; set; }
	
	[Column("RATING")]
	public short Rating { get; set; }
	
	[Column("COMMENT")]
	[StringLength(1000)]
	public string Comment { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[ForeignKey("ProductId")]
	[InverseProperty(nameof(Product.ProductReviews))]
	public virtual Product Product { get; set; } = null!;

}

