using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Dish;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Domain.Entities;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace RestaurantAPI.Core.Application.Services
{
    public class DishService : GenericService<SaveDishViewModel, DishViewModel, Dish>, IDishService
    {
        private readonly IDishRepository _dishRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public DishService(IDishRepository dish, IMapper mapper, IIngredientRepository ingredientRepository) : base(dish, mapper)
        {
            _ingredientRepository = ingredientRepository;
            _dishRepository = dish;
            _mapper = mapper;
        }
        public async override Task Add(SaveDishViewModel vm)
        {
            var dish = _mapper.Map<Dish>(vm);

            var ingredientIds = vm.Ingredients.Select(i => i.Id).ToList();
            var existingIngredients = await _ingredientRepository.GetAllByIds(ingredientIds);

            dish.Ingredients = existingIngredients;

            await _dishRepository.AddAsync(dish);

        }
        public async override Task<List<DishViewModel>> GetAll()
        {
            var entities = await _dishRepository.GetAllWithIncludeAsync(new List<string> { "Ingredients" });

            return _mapper.Map<List<DishViewModel>>(entities);
        }

        public async override Task<SaveDishViewModel> GetById(int id)
        {
            var entities = await _dishRepository.GetAllWithIncludeAsync(new List<string> { "Ingredients" });

            var entitie = entities.Find(d => d.Id == id);
            return _mapper.Map<SaveDishViewModel>(entitie);
        }

        public async override Task Update(SaveDishViewModel vm, int id)
        {
            Dish entity = _mapper.Map<Dish>(vm);

            var ingredientIds = vm.Ingredients.Select(i => i.Id).ToList();
            var existingIngredients = await _ingredientRepository.GetAllByIds(ingredientIds);
            
            entity.Ingredients = existingIngredients;
            await _dishRepository.UpdateAsync(entity, id);
        }
    }
}
