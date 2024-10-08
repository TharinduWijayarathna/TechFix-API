﻿using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.DTO
{
    public class CreateQuotationItemDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int QuotationId { get; set; }
        public int Quantity { get; set; } = 0;
        public string? Description { get; set; }
    }
}
