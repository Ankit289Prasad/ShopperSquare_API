using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperSquare.BL
{
    public class ItemGetBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int MRPAmount { get; set; }
        public int Discount { get; set; }
        public bool InStock { get; set; }
    }
}
