using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Publishing Context
        
      /*  builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        
        builder.Entity<Tutorial>().HasKey(t => t.Id);
        builder.Entity<Tutorial>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Tutorial>().Property(t => t.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Tutorial>().Property(t => t.Summary).HasMaxLength(240);

        builder.Entity<Asset>().HasDiscriminator(a => a.Type);
        builder.Entity<Asset>().HasKey(p => p.Id);
        builder.Entity<Asset>().HasDiscriminator<string>("asset_type")
            .HasValue<Asset>("asset_base")
            .HasValue<ImageAsset>("asset_image")
            .HasValue<VideoAsset>("asset_video")
            .HasValue<ReadableContentAsset>("asset_readable_content");

        builder.Entity<Asset>().OwnsOne(i => i.AssetIdentifier,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
        builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();
        builder.Entity<VideoAsset>().Property(p => p.VideoUri).IsRequired();
        builder.Entity<Tutorial>().HasMany(t => t.Assets);
        
        // Category Relationships
        builder.Entity<Category>()
            .HasMany(c => c.Tutorials)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .HasPrincipalKey(t => t.Id);
        */
        // Profiles Context
        
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Username,
            u =>
            {
                u.WithOwner().HasForeignKey("Id");
                u.Property(un => un.Username).HasColumnName("Username");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Password,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(ps => ps.Password).HasColumnName("Password");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("Email");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Subscription,
            s =>
            {
                s.WithOwner().HasForeignKey("Id");
                s.Property(sb => sb.SubscriptionDate).HasColumnName("SubscriptionDate");
                s.Property(sb => sb.SubscriptionPlan).HasColumnName("SubscriptionPlan");
            });
        
        // Subscriptions Context
        builder.Entity<Subscription>().HasKey(p => p.Id);
        builder.Entity<Subscription>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Subscription>().OwnsOne(s => s.Name,
            sn =>
            {
                sn.WithOwner().HasForeignKey("Id");
                sn.Property(n => n.Name).HasColumnName("Name");
            });
        builder.Entity<Subscription>().OwnsOne(s => s.MonthlyPrice,
            smp =>
            {
                smp.WithOwner().HasForeignKey("Id");
                smp.Property(mp => mp.MonthlyPrice).HasColumnName("MonthlyPrice");
            });
        builder.Entity<Subscription>().OwnsOne(s => s.Date,
            sd =>
            {
                sd.WithOwner().HasForeignKey("Id");
                sd.Property(d => d.Date).HasColumnName("Date");
            });
        
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}