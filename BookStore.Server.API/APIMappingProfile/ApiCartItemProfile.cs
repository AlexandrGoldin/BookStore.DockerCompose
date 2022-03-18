using AutoMapper;
using BookStore.Server.API.DTO;
using BookStore.Server.BLL.Models;

namespace BookStore.Server.API.APIMappingProfile
{
    public class ApiCartItemProfile: Profile
    {
        public ApiCartItemProfile()
        {
            CreateMap<CartItemModel, CartItemReadDto>();

            CreateMap<CartItemCreateDto, CartItemModel>();

        }
    }
}
