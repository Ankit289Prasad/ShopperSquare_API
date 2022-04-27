using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSquare.API.DTO.Request
{
    public class UserRequest
    {
        [Required]
        public string Name { get; set; }
        [Range(10,60)]
        public int Age { get; set; }
        public string EmailId { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password cannot be longer than 20 characters and less than 8 characters")]
        public string Password { get; set; }
    }
}
