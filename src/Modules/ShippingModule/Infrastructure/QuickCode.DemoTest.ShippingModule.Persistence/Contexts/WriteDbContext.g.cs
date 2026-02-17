using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoTest.ShippingModule.Domain.Entities;
using QuickCode.DemoTest.ShippingModule.Domain.Enums;

namespace QuickCode.DemoTest.ShippingModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Shipment> Shipment { get; set; }

	public virtual DbSet<ShippingCarrier> ShippingCarrier { get; set; }

	public virtual DbSet<DeliveryAddress> DeliveryAddress { get; set; }

	public virtual DbSet<ShipmentTrackingEvent> ShipmentTrackingEvent { get; set; }

	public virtual DbSet<ShippingRate> ShippingRate { get; set; }

	public virtual DbSet<DeliveryException> DeliveryException { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		var converterShipmentShippingStatus = new ValueConverter<ShippingStatus, string>(
		v => v.ToString(),
		v => (ShippingStatus)Enum.Parse(typeof(ShippingStatus), v));

		modelBuilder.Entity<Shipment>()
		.Property(b => b.ShippingStatus)
		.HasConversion(converterShipmentShippingStatus);

		modelBuilder.Entity<ShippingCarrier>()
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

		modelBuilder.Entity<Shipment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Shipment>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ShippingCarrier>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ShippingCarrier>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<DeliveryAddress>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<DeliveryAddress>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ShipmentTrackingEvent>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ShipmentTrackingEvent>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ShippingRate>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ShippingRate>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<DeliveryException>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<DeliveryException>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Shipment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ShippingCarrier>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<DeliveryAddress>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ShipmentTrackingEvent>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ShippingRate>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<DeliveryException>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Shipment>()
			.HasOne(e => e.ShippingCarrier)
			.WithMany(p => p.Shipments)
			.HasForeignKey(e => e.ShippingCarrierId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Shipment>()
			.HasOne(e => e.DeliveryAddress)
			.WithMany(p => p.Shipments)
			.HasForeignKey(e => e.DeliveryAddressId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ShipmentTrackingEvent>()
			.HasOne(e => e.Shipment)
			.WithMany(p => p.ShipmentTrackingEvents)
			.HasForeignKey(e => e.ShipmentId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<DeliveryException>()
			.HasOne(e => e.Shipment)
			.WithMany(p => p.DeliveryExceptions)
			.HasForeignKey(e => e.ShipmentId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
