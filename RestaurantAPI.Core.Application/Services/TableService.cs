using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Application.ViewModels.Table;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Services
{
    public class TableService : GenericService<SaveTableViewModel, TableViewModel, Table>, ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository table, IMapper mapper) : base(table, mapper)
        {
            _tableRepository = table;
            _mapper = mapper;
        }

        public async Task ChanceStatusTable(int id, string newStatus)
        {
            await _tableRepository.ChanceStatusTable(id, newStatus);
        }

        public async Task<List<OrderViewModel>> GetTableOrdenAsync(int id)
        {
           var tables = await _tableRepository.GetTableOrdenAsync(id);
           return  _mapper.Map<List<OrderViewModel>>(tables);

        }
    }
}