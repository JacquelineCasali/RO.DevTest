using System;
using System.ComponentModel.DataAnnotations;

namespace RO.DevTest.WebApi.Models
{
    public class SaleItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid SaleId { get; set; }
        
        public Sale Sale { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        
        public Product Product { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PriceAtSale { get; set; }
    }
}
