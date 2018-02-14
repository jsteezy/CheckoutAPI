using System.Collections.Generic;
using StrataTest.Models;

namespace StrataTest.Commands
{
    public class BasketCommand
    {
        public int BasketId { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
        public IEnumerable<ProductModel> Products { get; set;  }
    }
}