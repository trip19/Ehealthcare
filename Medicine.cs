using System;
using System.ComponentModel.DataAnnotations;

namespace E_Healthcare
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(100)]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }


        // Navigation property for Category
        public Category Category { get; set; }

        // Define a navigation property for CartItems
        public List<CartItem> CartItems { get; set; }
    }
}
