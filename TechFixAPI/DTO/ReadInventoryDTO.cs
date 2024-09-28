namespace TechFixAPI.DTO
{
    public class ReadInventoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 0;
        public string? Description { get; set; }
    }
}
