using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.DTO
{
    public class CreateOrderItemDTO
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public string? Description { get; set; }
    }
}
