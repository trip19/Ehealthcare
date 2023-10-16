using System;
using System.ComponentModel.DataAnnotations;

namespace E_Healthcare
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        public int MedicineId { get; set; }
        // Navigation property for Medicine
        public Medicine Medicine { get; set; }

        public int Quantity { get; set; }

        public int CartId { get; set; } // This property represents the foreign key to Cart
                                        // Navigation property for Cart
        public Cart Cart { get; set; }
    }
}
