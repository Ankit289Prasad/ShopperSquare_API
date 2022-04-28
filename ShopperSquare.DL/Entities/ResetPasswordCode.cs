using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopperSquare.DL.Entities
{
    public class ResetPasswordCode
    {
        [Key]
        public int CodeId { get; set; }
        public string UserEmail { get; set; }
        public string ResetCode { get; set; }
    }
}
