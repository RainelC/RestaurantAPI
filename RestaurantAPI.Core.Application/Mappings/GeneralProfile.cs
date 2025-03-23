using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.Account;
using RestaurantAPI.Core.Application.ViewModels.Dish;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Application.ViewModels.Table;
using RestaurantAPI.Core.Application.ViewModels.User;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Dish, DishViewModel>()
                .ReverseMap();

            CreateMap<Dish, SaveDishViewModel>()
                .ReverseMap();

            CreateMap<Ingredient, IngredientViewModel>()
                .ReverseMap();

            CreateMap<Ingredient, SaveIngredientViewModel>()
               .ReverseMap();

            CreateMap<IngredientViewModel, SaveIngredientViewModel>()
               .ReverseMap();

            CreateMap<Order, OrderViewModel>()
                .ReverseMap();

            CreateMap<Order, SaveOrderViewModel>()
               .ReverseMap()
                .ForMember(x => x.Table, opt => opt.Ignore());



            CreateMap<Table, TableViewModel>()
                .ReverseMap();

            CreateMap<Table, SaveTableViewModel>()
               .ReverseMap();

            CreateMap<UpdateTableViewModel, SaveTableViewModel>()
               .ForMember(x => x.Status, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<AuthenticationRequest, LoginViewModel>()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.ErrorMessage, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.ErrorMessage, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}
