﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperSquare.DL.Entities
{
    public class CartDetails
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int MRPAmount { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
