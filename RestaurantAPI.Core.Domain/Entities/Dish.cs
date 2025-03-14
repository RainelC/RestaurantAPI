using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PeoplePerDish { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string DishCategory { get; set; }
    }
}
