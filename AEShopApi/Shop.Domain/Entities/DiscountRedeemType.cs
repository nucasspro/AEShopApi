﻿using Shop.Domain.SeedWork;
using System.Collections.Generic;

namespace Shop.Domain.Entities
{
    public class DiscountRedeemType : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
    }
}