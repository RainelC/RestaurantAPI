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

        public async Task ChanceStatusTable(int id, string newStatus)
        {
            Table entry = await _dbContext.Set<Table>().FindAsync(id);
            var newEntry = entry.Status = newStatus;
            _dbContext.Entry(entry).CurrentValues.SetValues(newEntry);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task<Table> GetByIdAsync(int id)
        { 
            return await _dbContext.Tables.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

    }
}