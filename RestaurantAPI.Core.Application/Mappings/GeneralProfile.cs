using AutoMapper;
using RestaurantAPI.Core.Application.ViewModels.Dish;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Application.ViewModels.Table;
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
               .ReverseMap();

            CreateMap<Table, TableViewModel>()
                .ReverseMap();

            CreateMap<Table, SaveTableViewModel>()
               .ReverseMap();
        }
    }
}
