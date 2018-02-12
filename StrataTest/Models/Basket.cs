using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrataTest.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}