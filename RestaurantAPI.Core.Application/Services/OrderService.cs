using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Dish;
using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Application.ViewModels.Table;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Services
{
    public class OrderService : GenericService<SaveOrderViewModel, OrderViewModel, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository order, IMapper mapper, ITableRepository tableRepository, IDishRepository dishRepository) : base(order, mapper)
        {
            _orderRepository = order;
            _mapper = mapper;
            _tableRepository = tableRepository;
            _dishRepository = dishRepository;
        }

        public override async Task Update(SaveOrderViewModel vm, int id)
        {
            vm.Id = id;
            var exitTable = await _tableRepository.GetByIdAsync(vm.TableId);
            if (exitTable == null)
            {
                throw new Exception("Table not found");
            }
            vm.TableId = exitTable.Id; var dishesIds = vm.Dishes.Select(i => i.Id).ToList();
            var existingDishes = await _dishRepository.GetAllByIds(dishesIds);
            vm.Dishes = _mapper.Map<List<DishViewModel>>(existingDishes);

            Order entity = _mapper.Map<Order>(vm);
            await _orderRepository.UpdateAsync(entity, id);
        }
        public override async Task Add(SaveOrderViewModel vm)
        { 
            var exitTable = await _tableRepository.GetByIdAsync(vm.TableId);
            if (exitTable == null)
            {
                throw new Exception("Table not found");
            }
            vm.TableId = exitTable.Id;

            var dishesIds = vm.Dishes.Select(i => i.Id).ToList();
            var existingDishes = await _dishRepository.GetAllByIds(dishesIds);
            vm.Dishes = _mapper.Map<List<DishViewModel>>(existingDishes.ToList());
            Order entity = _mapper.Map<Order>(vm);
            await _orderRepository.AddAsync(entity);
        }

        public override async Task<List<OrderViewModel>> GetAll()
        {
            var orders = await _orderRepository.GetAllWithIncludeAsync(new List<string> { "Table", "Dishes" });
            return _mapper.Map<List<OrderViewModel>>(orders);
        }
    }
}
