using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Entities;
using QuickCode.DemoTest.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoTest.ProductCatalogModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Product> Product { get; set; }

	public virtual DbSet<ProductCategory> ProductCategory { get; set; }

	public virtual DbSet<ProductImage> ProductImage { get; set; }

	public virtual DbSet<ProductBrand> ProductBrand { get; set; }

	public virtual DbSet<ProductReview> ProductReview { get; set; }

	public virtual DbSet<ProductSpecification> ProductSpecification { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		var converterProductStatus = new ValueConverter<ProductStatus, string>(
		v => v.ToString(),
		v => (ProductStatus)Enum.Parse(typeof(ProductStatus), v));

		modelBuilder.Entity<Product>()
		.Property(b => b.Status)
		.HasConversion(converterProductStatus);


		var converterProductVisibility = new ValueConverter<ProductVisibility, string>(
		v => v.ToString(),
		v => (ProductVisibility)Enum.Parse(typeof(ProductVisibility), v));

		modelBuilder.Entity<Product>()
		.Property(b => b.Visibility)
		.HasConversion(converterProductVisibility);

		modelBuilder.Entity<ProductCategory>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<ProductImage>()
		.Property(b => b.IsPrimary)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<ProductBrand>()
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

		modelBuilder.Entity<Product>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Product>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ProductCategory>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ProductCategory>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ProductImage>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ProductImage>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ProductBrand>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ProductBrand>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ProductReview>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ProductReview>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ProductSpecification>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ProductSpecification>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Product>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ProductCategory>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ProductImage>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ProductBrand>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ProductReview>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ProductSpecification>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Product>()
			.HasOne(e => e.ProductCategory)
			.WithMany(p => p.Products)
			.HasForeignKey(e => e.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Product>()
			.HasOne(e => e.ProductBrand)
			.WithMany(p => p.Products)
			.HasForeignKey(e => e.BrandId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ProductImage>()
			.HasOne(e => e.Product)
			.WithMany(p => p.ProductImages)
			.HasForeignKey(e => e.ProductId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ProductReview>()
			.HasOne(e => e.Product)
			.WithMany(p => p.ProductReviews)
			.HasForeignKey(e => e.ProductId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ProductSpecification>()
			.HasOne(e => e.Product)
			.WithMany(p => p.ProductSpecifications)
			.HasForeignKey(e => e.ProductId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
