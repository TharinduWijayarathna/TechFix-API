﻿using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.DTO
{
    public class ReadQuoteRequestItemDTO
    {
        public int Id { get; set; }
        public int QuoteRequestId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
}
