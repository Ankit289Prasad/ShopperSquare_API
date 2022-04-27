using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSquare.API.DTO.Response
{
    public class CartResponse
    {
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int MRPAmount { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
