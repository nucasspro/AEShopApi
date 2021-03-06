﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Domain.EntitiesConfiguration
{
    public class DiscountConfiguration : BaseConfiguration<Discount>
    {
        public override void Configure(EntityTypeBuilder<Discount> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(50)");
            builder.Property(x => x.DisplayName).IsRequired(false).HasColumnName("DisplayName").HasColumnType("nvarchar(50)");
            builder.Property(x => x.DiscountValue).IsRequired(false).HasColumnName("DiscountValue").HasColumnType("float");
            builder.Property(x => x.MaximumDiscount).IsRequired(false).HasColumnName("MaximumDiscount").HasColumnType("float");
            builder.Property(x => x.StartedTime).IsRequired(false).HasColumnName("StartedTime").HasColumnType("int");
            builder.Property(x => x.ExpriredTime).IsRequired(false).HasColumnName("ExpriredTime").HasColumnType("int");
            builder.Property(x => x.CouponCode).IsRequired(false).HasColumnName("CouponCode").HasColumnType("varchar(15)");

            builder.Property(x => x.DiscountActiveTypeId).IsRequired(false).HasColumnName("DiscountActiveTypeId").HasColumnType("int");
            builder.HasOne(x => x.DiscountActiveType).WithMany(y => y.Discounts).HasForeignKey(z => z.DiscountActiveTypeId);

            builder.Property(x => x.DiscountRedeemTypeId).IsRequired(false).HasColumnName("DiscountRedeemTypeId").HasColumnType("int");
            builder.HasOne(x => x.DiscountRedeemType).WithMany(y => y.Discounts).HasForeignKey(z => z.DiscountRedeemTypeId);
        }
    }
}