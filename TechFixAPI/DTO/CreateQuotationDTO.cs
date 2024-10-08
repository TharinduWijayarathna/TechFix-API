﻿using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.DTO
{
    public class CreateQuotationDTO
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}
