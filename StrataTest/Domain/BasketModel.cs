using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrataTest.Models
{
    public class BasketModel
    {
        [Key]
        public int BasketId { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
        public IEnumerable<ProductModel> Products { get; set;  }
    }
}