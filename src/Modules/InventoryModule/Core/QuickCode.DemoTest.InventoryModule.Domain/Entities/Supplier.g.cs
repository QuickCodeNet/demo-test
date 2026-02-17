using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoTest.InventoryModule.Domain;
using QuickCode.DemoTest.Common;
using QuickCode.DemoTest.Common.Auditing;

namespace QuickCode.DemoTest.InventoryModule.Domain.Entities;

[Table("SUPPLIERS")]
public partial class Supplier : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("CONTACT_NAME")]
	[StringLength(250)]
	public string ContactName { get; set; }
	
	[Column("CONTACT_EMAIL")]
	[StringLength(500)]
	public string ContactEmail { get; set; }
	
	[Column("CONTACT_PHONE")]
	[StringLength(50)]
	public string ContactPhone { get; set; }
	}

