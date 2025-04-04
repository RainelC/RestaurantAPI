﻿using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Domain.Entities;


namespace RestaurantAPI.Infrastructure.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tablas

            modelBuilder.Entity<Ingredient>().ToTable("Ingredients");
            modelBuilder.Entity<Dish>().ToTable("Dishes");
            modelBuilder.Entity<Table>().ToTable("Tables");
            modelBuilder.Entity<Order>().ToTable("Orders");

            // Primary Keys

            modelBuilder.Entity<Ingredient>().HasKey(u => u.Id);
            modelBuilder.Entity<Dish>().HasKey(u => u.Id);
            modelBuilder.Entity<Table>().HasKey(u => u.Id);
            modelBuilder.Entity<Order>().HasKey(u => u.Id);

            // RelationShips

            modelBuilder.Entity<Dish>()
                .HasMany(d => d.Ingredients)
                .WithMany(i => i.dishes)
                .UsingEntity<Dictionary<string, object>>(
                "DishIngredient",
                j => j.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientsId"),
                j => j.HasOne<Dish>().WithMany().HasForeignKey("dishesId"));

            modelBuilder.Entity<Order>()
                .HasMany(u => u.Dishes)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(u => u.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(u => u.TableId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
