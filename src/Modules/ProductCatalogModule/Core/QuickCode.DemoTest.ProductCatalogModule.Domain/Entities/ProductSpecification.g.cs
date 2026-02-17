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

[Table("PRODUCT_SPECIFICATIONS")]
public partial class ProductSpecification : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PRODUCT_ID")]
	public int ProductId { get; set; }
	
	[Column("SPECIFICATION_KEY")]
	[StringLength(250)]
	public string SpecificationKey { get; set; }
	
	[Column("SPECIFICATION_VALUE")]
	[StringLength(250)]
	public string SpecificationValue { get; set; }
	
	[ForeignKey("ProductId")]
	[InverseProperty(nameof(Product.ProductSpecifications))]
	public virtual Product Product { get; set; } = null!;

}

