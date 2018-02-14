﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrataTest.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}