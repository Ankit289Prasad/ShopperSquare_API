using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopperSquare.DL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(102)]
        public string Name { get; set; }
        public string EmailId { get; set; }
        [Range(10, 60)]
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password cannot be longer than 20 characters and less than 8 characters")]
        public string Password { get; set; }
    }
}
