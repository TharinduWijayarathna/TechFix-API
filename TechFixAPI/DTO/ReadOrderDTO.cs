﻿namespace TechFixAPI.DTO
{
    public class ReadOrderDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
    }
}
