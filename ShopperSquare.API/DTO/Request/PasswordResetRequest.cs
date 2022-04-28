using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSquare.API.DTO.Request
{
    public class PasswordResetRequest
    {
        public string Email { get; set; }
        public string ResetCode { get; set; }
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password cannot be longer than 20 characters and less than 8 characters")]
        public string NewPassword { get; set; }
    }
}
