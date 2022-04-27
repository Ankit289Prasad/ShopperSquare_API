using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSquare.API.DTO.Request
{
    public class LoginRequest
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
