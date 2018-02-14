using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrataTest.Models
{
    public class BasketModel
    {
        public int BasketId { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
        public IEnumerable<ProductModel> Products { get; set;  }
    }
}