﻿namespace RestaurantAPI.Core.Domain.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int CapacityPeople { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public List<Order> Orders { get; set; }
    }
}
