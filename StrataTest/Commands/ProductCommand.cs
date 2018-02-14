using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrataTest.Commands
{
    public class ProductCommand
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}