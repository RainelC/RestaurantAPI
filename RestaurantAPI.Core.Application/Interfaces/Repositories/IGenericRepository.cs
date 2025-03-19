
namespace RestaurantAPI.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task AddAsync(Entity entity);
        Task UpdateAsync(Entity entity, int id);
        Task DeleteAsync(Entity entity);
        Task<Entity> GetByIdAsync(int id);
        Task<List<Entity>> GetAllAsync();
        Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties);
    }
}
