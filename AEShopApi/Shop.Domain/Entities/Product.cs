﻿using Shop.Domain.SeedWork;
using System.Collections.Generic;

namespace Shop.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescriptions { get; set; }
        public string MetaKeywords { get; set; }
        public string ProductImage { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public float? PromotionPrice { get; set; }
        public float? RegularPrice { get; set; }
        public bool? IncludeVAT { get; set; }
        public float? Weight { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public float? Length { get; set; }
        public string Warranty { get; set; }
        public int? ViewCounts { get; set; }

        public int? ProductStatusTypeId { get; set; }
        public ProductStatusType ProductStatusType { get; set; }

        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}