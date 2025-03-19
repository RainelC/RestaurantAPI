using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IOrderService : IGenericService<SaveOrderViewModel, OrderViewModel, Order>
    {
    }
}
