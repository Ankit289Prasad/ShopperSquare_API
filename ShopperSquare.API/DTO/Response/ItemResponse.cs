using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSquare.API.DTO.Response
{
    public class ItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int MRPAmount { get; set; }
        public int Discount { get; set; }
        public bool InStock { get; set; }

    }
}
