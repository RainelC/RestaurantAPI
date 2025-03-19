using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Services
{
    public class OrderService : GenericService<SaveOrderViewModel, OrderViewModel, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository order, IMapper mapper) : base(order, mapper)
        {
            _orderRepository = order;
            _mapper = mapper;
        }
    }
}
