using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperSquare.BL
{
    public class ItemBL
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int MRPAmount { get; set; }
        public int DiscountPercentage { get; set; }
        public bool InStock { get; set; }
        public int MaxOrderAmount { get; set; }
        public string InventoryId { get; set; }
        public int CategoryId { get; set; }
    }
}
