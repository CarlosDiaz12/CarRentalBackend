﻿using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.Entities
{
    public class Client: BaseEntity
    {
        public string Name { get; set; }
        public string IdentificationCard { get; set; }
        public string CreditCardNumber { get; set; }
        public decimal CreditLimit { get; set; }
        public TaxPayerType TaxPayerType { get; set; }
    }
}
