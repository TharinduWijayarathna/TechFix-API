using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.DTO
{
    public class CreateQuoteRequestItemDTO
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int QuoteRequestId { get; set; }
        public string? Description { get; set; }
    }
}
