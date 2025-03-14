using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;

namespace RestaurantAPI.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Entity> : IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _Repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _Repository = repository;
            _mapper = mapper;
        }
        public virtual async Task Add(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _Repository.AddAsync(entity);
        }

        public virtual async Task Delete(int id)
        {
            Entity entity = await _Repository.GetByIdAsync(id);
            await _Repository.DeleteAsync(entity);
        }

        public virtual async Task<List<ViewModel>> GetAll()
        {
            var entities = await _Repository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(entities);
        }
        public virtual async Task<SaveViewModel> GetById(int id)
        {
            var entity = await _Repository.GetByIdAsync(id);

            SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);
            return vm;
        }
        public virtual async Task Update(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _Repository.UpdateAsync(entity, id);
        }
    }
}