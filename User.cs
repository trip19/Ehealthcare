using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace E_Healthcare
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Cart Cart { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } // Add the Role property
    }
}
