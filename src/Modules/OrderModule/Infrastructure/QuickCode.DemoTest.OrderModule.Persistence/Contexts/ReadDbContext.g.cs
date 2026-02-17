using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoTest.OrderModule.Domain.Entities;
using QuickCode.DemoTest.OrderModule.Domain.Enums;

namespace QuickCode.DemoTest.OrderModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<Order> Order { get; set; }

	public virtual DbSet<OrderItem> OrderItem { get; set; }

	public virtual DbSet<ShippingAddress> ShippingAddress { get; set; }

	public virtual DbSet<BillingAddress> BillingAddress { get; set; }

	public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }

	public virtual DbSet<OrderNote> OrderNote { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		var converterOrderOrderStatus = new ValueConverter<OrderStatus, string>(
		v => v.ToString(),
		v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));

		modelBuilder.Entity<Order>()
		.Property(b => b.OrderStatus)
		.HasConversion(converterOrderOrderStatus);


		var converterOrderPaymentStatus = new ValueConverter<PaymentStatus, string>(
		v => v.ToString(),
		v => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), v));

		modelBuilder.Entity<Order>()
		.Property(b => b.PaymentStatus)
		.HasConversion(converterOrderPaymentStatus);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Order>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Order>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<OrderItem>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<OrderItem>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ShippingAddress>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ShippingAddress>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<BillingAddress>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<BillingAddress>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<PaymentMethod>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<PaymentMethod>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<OrderNote>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<OrderNote>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Order>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<OrderItem>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ShippingAddress>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<BillingAddress>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<PaymentMethod>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<OrderNote>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Order>()
			.HasOne(e => e.ShippingAddress)
			.WithMany(p => p.Orders)
			.HasForeignKey(e => e.ShippingAddressId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Order>()
			.HasOne(e => e.BillingAddress)
			.WithMany(p => p.Orders)
			.HasForeignKey(e => e.BillingAddressId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Order>()
			.HasOne(e => e.PaymentMethod)
			.WithMany(p => p.Orders)
			.HasForeignKey(e => e.PaymentMethodId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<OrderItem>()
			.HasOne(e => e.Order)
			.WithMany(p => p.OrderItems)
			.HasForeignKey(e => e.OrderId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<OrderNote>()
			.HasOne(e => e.Order)
			.WithMany(p => p.OrderNotes)
			.HasForeignKey(e => e.OrderId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public override int SaveChanges()
    {
        throw new InvalidOperationException("ReadDbContext is read-only.");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("ReadDbContext is read-only.");
    }

}
