﻿using Shop.Domain.SeedWork;
using System.Collections.Generic;

namespace Shop.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public string OrderCode { get; set; }
        public float? SubTotal { get; set; }
        public float? GrandTotal { get; set; }

        public int? OrderStatusTypeId { get; set; }
        public virtual OrderStatusType OrderStatusType { get; set; }

        public bool? IsVerify { get; set; }

        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }

        public float? PackageWidth { get; set; }
        public float? PackageHeight { get; set; }
        public float? PackageLength { get; set; }

        public int? PaymentMethodId { get; set; }
        public virtual Payment Payment { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}