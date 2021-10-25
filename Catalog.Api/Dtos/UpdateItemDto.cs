using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }
    }
}