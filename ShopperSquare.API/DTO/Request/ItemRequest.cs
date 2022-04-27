using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSquare.API.DTO.Request
{
    public class ItemRequest
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
