namespace RestaurantAPI.Core.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Dish> dishes { get; set; }
    }
}
