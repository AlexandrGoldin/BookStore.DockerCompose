namespace BookStore.Server.API.DTO
{
    public class ProductCreateDto
    {
        //[Key]
        //public int Id { get; set; }

        //[JsonPropertyName("title")]
        //public string Title { get; set; }

        //[JsonPropertyName("author")]
        //public string Author { get; set; }

        //[JsonPropertyName("image")]
        //public string Image { get; set; }

        //[JsonPropertyName("price")]
        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal Price { get; set; }

        //[JsonPropertyName("genre")]
        //public string Genre { get; set; }

        //[JsonPropertyName("rating")]
        //public int Rating { get; set; }

        //[JsonPropertyName("description")]
        //public string Description { get; set; }

        //2
        public string Title { get; set; }

        public string Author { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public string Genre { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }
    }
}
