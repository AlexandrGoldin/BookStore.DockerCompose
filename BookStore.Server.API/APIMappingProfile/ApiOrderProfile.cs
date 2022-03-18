using AutoMapper;
using BookStore.Server.API.DTO;
using BookStore.Server.BLL.Models;

namespace BookStore.Server.API.APIMappingProfile
{
    public class ApiOrderProfile:Profile
    {
        public ApiOrderProfile()
        {
            CreateMap<OrderModel, OrderReadDto>();
            CreateMap<OrderCreateDto, OrderModel>();
        }
    }
}
