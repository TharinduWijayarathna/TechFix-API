﻿using System.ComponentModel.DataAnnotations;

namespace TechFixAPI.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
