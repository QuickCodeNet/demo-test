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

[Table("PRODUCT_IMAGES")]
public partial class ProductImage : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PRODUCT_ID")]
	public int ProductId { get; set; }
	
	[Column("IMAGE_URL")]
	[StringLength(1000)]
	public string ImageUrl { get; set; }
	
	[Column("IS_PRIMARY")]
	public bool IsPrimary { get; set; }
	
	[ForeignKey("ProductId")]
	[InverseProperty(nameof(Product.ProductImages))]
	public virtual Product Product { get; set; } = null!;

}

