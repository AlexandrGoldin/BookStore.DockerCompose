using BookStore.Server.BLL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookStore.Server.API.DTO
{
    public class CartItemCreateDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("cartItemId")]
        public int Id { get; set; }

        [JsonIgnore]
        public int OrderId { get; set; }

        [JsonPropertyName("id")]
        public int ProductId { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonIgnore]
        public ProductCreateDto Product { get; set; }

        [JsonIgnore]
        public OrderCreateDto Order { get; set; }
    }
}
