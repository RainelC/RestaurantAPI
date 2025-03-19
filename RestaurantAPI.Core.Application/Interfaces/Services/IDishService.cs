using RestaurantAPI.Core.Application.ViewModels.Dish;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IDishService : IGenericService<SaveDishViewModel, DishViewModel, Dish>
    {
    }
}
