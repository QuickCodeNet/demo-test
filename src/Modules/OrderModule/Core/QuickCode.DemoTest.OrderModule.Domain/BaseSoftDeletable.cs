using System;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoTest.Common;

namespace QuickCode.DemoTest.OrderModule.Domain;

public class BaseSoftDeletable : ISoftDeletable
{
    [Column("IsDeleted")]
    public bool IsDeleted { get; set; }
    
    [Column("DeletedOnUtc")]
    public DateTime? DeletedOnUtc { get; set; }
}