using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Core.Application.ViewModels.Dish
{
    public class SaveDishViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Debe colocar el nombre.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre.")]
        [DataType(DataType.Text)]
        public double Price { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre.")]
        [DataType(DataType.Text)]
        public int PeoplePerDish { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
        public string DishCategory { get; set; }
    }
}
