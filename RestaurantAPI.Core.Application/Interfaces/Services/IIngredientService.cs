using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IIngredientService : IGenericService<SaveIngredientViewModel, IngredientViewModel, Ingredient>
    {
    }
}
