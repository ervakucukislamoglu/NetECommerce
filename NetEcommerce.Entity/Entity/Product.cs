using NetEcommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetEcommerce.Entity.Entity
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public short UnitsInStock { get; set; }
    }
}
