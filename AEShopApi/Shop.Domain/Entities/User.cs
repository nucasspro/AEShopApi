﻿using Shop.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}