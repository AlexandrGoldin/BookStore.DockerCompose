using AutoMapper;
using BookStore.Server.BLL.Models;
using BookStore.Server.DAL.Entities;

namespace BookStore.Server.BLL.BLLMappingProfile
{
    public class CartItemProfile:Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, CartItemModel>();

            CreateMap<CartItemModel, CartItem>();
             
        }
    }
}
