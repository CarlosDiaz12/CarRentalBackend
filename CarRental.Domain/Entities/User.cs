﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
