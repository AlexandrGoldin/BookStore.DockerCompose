using BookStore.Server.BLL.Models;
using BookStore.Server.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookStore.Server.API.DTO
{
    public class OrderReadDto
    {
        public OrderReadDto()
        {
            CartItems = new List<CartItemReadDto>();
            OrderDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

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

        public List<CartItemReadDto> CartItems { get; set; }
    }
}
