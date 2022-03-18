using AutoMapper;
using BookStore.Server.BLL.Models;
using BookStore.Server.DAL.Entities;

namespace BookStore.Server.BLL.BLLMappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>();
             
            CreateMap<ProductModel, Product>();
        }
    }
}
