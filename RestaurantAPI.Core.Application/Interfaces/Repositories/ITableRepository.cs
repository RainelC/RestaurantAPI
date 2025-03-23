using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Repositories
{
    public interface ITableRepository : IGenericRepository<Table>
    {
        Task<List<Order>> GetTableOrdenAsync(int id);
        Task ChanceStatusTable(int id, string newStatus);
    }
}
