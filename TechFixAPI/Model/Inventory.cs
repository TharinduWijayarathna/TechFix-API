using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.Model
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; } = 0;
        public string? Description { get; set; }
    }
}
