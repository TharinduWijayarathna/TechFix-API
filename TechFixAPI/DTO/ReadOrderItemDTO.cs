namespace TechFixAPI.DTO
{
    public class ReadOrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
}
