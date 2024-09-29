using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.DTO
{
    public class CreateQuoteRequestDTO
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
