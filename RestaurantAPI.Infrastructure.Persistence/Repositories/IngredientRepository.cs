using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence.Contexts;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        private readonly AppDbContext _dbContext;
        public IngredientRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<Ingredient>> GetAllByIds(List<int> ids)
        {
            return await _dbContext.Ingredients.Where(i => ids.Contains(i.Id)).ToListAsync();
        }

    }
}