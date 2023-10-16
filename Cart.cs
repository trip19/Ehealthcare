using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Healthcare
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int UserId { get; set; }

        // Navigation property for User
        public User User { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
