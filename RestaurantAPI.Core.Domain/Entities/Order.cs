namespace RestaurantAPI.Core.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double Subtotal { get; set; }
        public string Status { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public List<Dish> Dishes { get; set; }

    }
}
