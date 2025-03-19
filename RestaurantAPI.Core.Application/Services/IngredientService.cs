using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Services
{
    public class IngredientService : GenericService<SaveIngredientViewModel, IngredientViewModel, Ingredient>, IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository ingredient, IMapper mapper) : base(ingredient, mapper)
        {
            _ingredientRepository = ingredient;
            _mapper = mapper;
        }
    }
}
