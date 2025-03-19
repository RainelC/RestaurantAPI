using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence.Contexts;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private readonly AppDbContext _dbContext;
        public TableRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<Order>> GetTableOrdenAsync(int id)
        {
            return await _dbContext.Set<Order>()
                .Where(o => o.Id == id || o.Status == "En proceso de atención")
                .ToListAsync();
        }
    }
}