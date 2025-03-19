using RestaurantAPI.Core.Application.ViewModels.Ingredient;

namespace RestaurantAPI.Core.Application.ViewModels.Dish
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PeoplePerDish { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
        public string DishCategory { get; set; }
    }
}
