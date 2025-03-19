using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModels.Ingredient
{
    public class SaveIngredientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
