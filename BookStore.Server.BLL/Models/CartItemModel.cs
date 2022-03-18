using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookStore.Server.BLL.Models
{
    public class CartItemModel
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
        public ProductModel Product { get; set; }

        [JsonIgnore]
        public OrderModel Order { get; set; }
    }
}
