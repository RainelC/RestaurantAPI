using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Repositories
{
    public interface IDishRepository : IGenericRepository<Dish>
    {
        Task<List<Dish>> GetAllByIds(List<int> ids);

    }
}
