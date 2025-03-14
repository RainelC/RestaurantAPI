using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class DishRepository :GenericRepository<Dish>, IDishRepository
    {
        private readonly AppDbContext _dbContext;
        public DishRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
