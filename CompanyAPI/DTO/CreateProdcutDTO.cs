using System.ComponentModel.DataAnnotations;
namespace CompanyAPI.DTO
{
    public class CreateProdcutDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string? Description { get; set; }
    }
}
