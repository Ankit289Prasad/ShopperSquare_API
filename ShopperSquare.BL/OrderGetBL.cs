using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperSquare.BL
{
    public class OrderGetBL
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int MRPAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
