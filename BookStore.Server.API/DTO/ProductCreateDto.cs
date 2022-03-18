using System.ComponentModel.DataAnnotations;

namespace BookStore.Server.API.DTO
{
    public class ProductCreateDto
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public string Genre { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }
    }
}
