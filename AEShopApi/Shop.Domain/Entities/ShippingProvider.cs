﻿using Shop.Domain.SeedWork;
using System.Collections.Generic;

namespace Shop.Domain.Entities
{
    public class ShippingProvider : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}