using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopperSquare.DL.Entities
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int ItemCount { get; set; }
        public int MRPAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountAmount { get; set; } 
    }
}
