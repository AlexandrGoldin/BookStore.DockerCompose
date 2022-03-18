using AutoMapper;
using BookStore.Server.BLL.Models;
using BookStore.Server.DAL.Entities;

namespace BookStore.Server.BLL.BLLMappingProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderModel>(); 
            
            CreateMap<OrderModel, Order>();

            CreateMap<Order, OrderModel>();

            CreateMap<OrderModel, Order>();

        }
    }
}
