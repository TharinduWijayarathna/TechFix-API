using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.Model
{
    public class QuoteRequestItem
    {
        [Key]
        public int Id { get; set; }
        public int QuoteRequestId { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
}
