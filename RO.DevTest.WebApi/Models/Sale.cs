using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RO.DevTest.WebApi.Models
{
    public class Sale
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ClientId { get; set; }
        
        public Client Client { get; set; }

        [Required]
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal TotalAmount { get; set; }

        public List<SaleItem> Items { get; set; }
    }
}
