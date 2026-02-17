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

[Table("PRODUCT_BRANDS")]
public partial class ProductBrand : BaseSoftDeletable, IAuditableEntity 
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
	
	[Column("LOGO_URL")]
	[StringLength(1000)]
	public string LogoUrl { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Product.ProductBrand))]
	public virtual ICollection<Product> Products { get; } = new List<Product>();

}

