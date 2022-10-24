using AutoMapper;
using Domain;
using Restaurant.Application.Model;

namespace Restaurant.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RestaurantDTO, Shop>();
            CreateMap<MenuDTO, Menu>();
            CreateMap<DrinkDTO, Drink>();
            CreateMap<BurgerDTO, Burger>();

            CreateMap<Shop, ShopResponseDTO>()
                .ForAllMembers(m => m.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}