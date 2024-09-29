using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.Model
{
    public class QuotationItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 0;
        public string? Description { get; set; }
    }
}
