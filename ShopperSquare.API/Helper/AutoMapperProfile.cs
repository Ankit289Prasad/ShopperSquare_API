using AutoMapper;
using ShopperSquare.API.DTO.Request;
using ShopperSquare.API.DTO.Response;
using ShopperSquare.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSquare.API.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRequest, UserBL>().ReverseMap();

            CreateMap<LoginRequest, UserLoginBL>().ReverseMap();

            CreateMap<ItemRequest, ItemBL>().ReverseMap();

            CreateMap<ItemResponse, ItemGetBL>().ReverseMap();

            CreateMap<CartResponse, CartGetBL>().ReverseMap();

            CreateMap<OrderResponse, OrderGetBL>().ReverseMap();
        }
    }
}
