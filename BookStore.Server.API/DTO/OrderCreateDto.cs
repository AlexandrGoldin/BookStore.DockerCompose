using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookStore.Server.API.DTO
{
    public class OrderCreateDto
    {
        public OrderCreateDto()
        {
            CartItems = new List<CartItemCreateDto>();
            OrderDate = DateTime.Now;
        }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [JsonPropertyName("total")]
        public decimal Total { get; set; }

        public List<CartItemCreateDto> CartItems { get; set; }
    }
}
