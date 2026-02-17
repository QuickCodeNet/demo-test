using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoTest.InventoryModule.Domain.Entities;

namespace QuickCode.DemoTest.InventoryModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Warehouse> Warehouse { get; set; }

	public virtual DbSet<Stock> Stock { get; set; }

	public virtual DbSet<StockMovement> StockMovement { get; set; }

	public virtual DbSet<ReorderPoint> ReorderPoint { get; set; }

	public virtual DbSet<InventoryAdjustment> InventoryAdjustment { get; set; }

	public virtual DbSet<Supplier> Supplier { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Warehouse>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Warehouse>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Warehouse>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Stock>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Stock>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<StockMovement>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<StockMovement>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ReorderPoint>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ReorderPoint>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<InventoryAdjustment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<InventoryAdjustment>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Supplier>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Supplier>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Warehouse>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Stock>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<StockMovement>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ReorderPoint>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<InventoryAdjustment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Supplier>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Stock>()
			.HasOne(e => e.Warehouse)
			.WithMany(p => p.Stocks)
			.HasForeignKey(e => e.WarehouseId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<StockMovement>()
			.HasOne(e => e.Warehouse)
			.WithMany(p => p.StockMovements)
			.HasForeignKey(e => e.WarehouseId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ReorderPoint>()
			.HasOne(e => e.Warehouse)
			.WithMany(p => p.ReorderPoints)
			.HasForeignKey(e => e.WarehouseId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<InventoryAdjustment>()
			.HasOne(e => e.Warehouse)
			.WithMany(p => p.InventoryAdjustments)
			.HasForeignKey(e => e.WarehouseId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
