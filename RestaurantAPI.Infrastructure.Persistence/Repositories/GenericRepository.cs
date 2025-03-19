using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Infrastructure.Persistence.Contexts;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext context)
        {

            _dbContext = context;
        }

        public virtual async Task AddAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(Entity entity, int id)
        {
            Entity entry = await _dbContext.Set<Entity>().FindAsync(id);
            _dbContext.Entry(entry).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _dbContext.Set<Entity>().ToListAsync();
        }

        public virtual async Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _dbContext.Set<Entity>().AsQueryable();

            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            
            return await query.ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Entity>().FindAsync(id);
        }
    }
}
