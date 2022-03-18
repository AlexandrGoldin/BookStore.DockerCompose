using AutoMapper;
using BookStore.Server.API.DTO;
using BookStore.Server.BLL.Models;

namespace BookStore.Server.API.APIMappingProfile
{
    public class ApiProductProfile:Profile
    {
        public ApiProductProfile()
        {
            CreateMap<ProductModel, ProductReadDto>();
            CreateMap<ProductCreateDto, ProductModel>();
        }
    }
}
