using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Healthcare
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Navigation property for Medicines in this category
        public List<Medicine> Medicines { get; set; }
    }
}
