using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.Model
{
    public class Quotation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
    }
}
