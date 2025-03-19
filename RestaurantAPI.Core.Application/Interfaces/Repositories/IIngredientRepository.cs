using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Repositories
{
    public interface IIngredientRepository : IGenericRepository<Ingredient>
    {
        Task<List<Ingredient>> GetAllByIds(List<int> ids);
    }
}
