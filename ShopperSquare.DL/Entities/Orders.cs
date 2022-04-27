using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopperSquare.DL.Entities
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int MRPAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
