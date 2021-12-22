using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.Models
{
    public record Item
    {
        public Guid Id { get; init; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}