﻿using System;

namespace Multitenant.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string Website { get; set; }
    }
}