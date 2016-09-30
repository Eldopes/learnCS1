using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeServices.Models
{
    public class Product 
    {
        public int ProductId { get; set; } // represent methods  getValue() and setValue()
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Size { get; set; }
        public string Category { get; set; }
    }
}