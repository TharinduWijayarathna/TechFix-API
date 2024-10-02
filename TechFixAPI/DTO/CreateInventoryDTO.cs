using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.DTO
{
    public class CreateInventoryDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Quantity { get; set; } = 0;

        public int SupplierId { get; set; }
        public string? Description { get; set; }
    }
}
