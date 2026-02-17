using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoTest.ProductCatalogModule.Domain;
using QuickCode.DemoTest.Common;
using QuickCode.DemoTest.Common.Auditing;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoTest.ProductCatalogModule.Domain.Entities;

[Table("PRODUCTS")]
public partial class Product : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("SKU")]
	[StringLength(250)]
	public string Sku { get; set; }
	
	[Column("PRICE")]
	[Precision(18,2)]
	public decimal Price { get; set; }
	
	[Column("CATEGORY_ID")]
	public int CategoryId { get; set; }
	
	[Column("BRAND_ID")]
	public int BrandId { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public ProductStatus Status { get; set; }
	
	[Column("VISIBILITY", TypeName = "nvarchar(250)")]
	public ProductVisibility Visibility { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(ProductImage.Product))]
	public virtual ICollection<ProductImage> ProductImages { get; } = new List<ProductImage>();


	[InverseProperty(nameof(ProductReview.Product))]
	public virtual ICollection<ProductReview> ProductReviews { get; } = new List<ProductReview>();


	[InverseProperty(nameof(ProductSpecification.Product))]
	public virtual ICollection<ProductSpecification> ProductSpecifications { get; } = new List<ProductSpecification>();


	[ForeignKey("CategoryId")]
	[InverseProperty(nameof(ProductCategory.Products))]
	public virtual ProductCategory ProductCategory { get; set; } = null!;


	[ForeignKey("BrandId")]
	[InverseProperty(nameof(ProductBrand.Products))]
	public virtual ProductBrand ProductBrand { get; set; } = null!;

}

