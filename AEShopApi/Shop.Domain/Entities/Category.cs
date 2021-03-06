﻿using Shop.Domain.SeedWork;
using System.Collections.Generic;

namespace Shop.Domain.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public int CategoryStatusTypeId { get; set; }
        public virtual CategoryStatusType CategoryStatusType { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}