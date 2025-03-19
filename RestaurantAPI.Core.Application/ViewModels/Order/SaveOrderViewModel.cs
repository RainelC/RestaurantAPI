using RestaurantAPI.Core.Application.ViewModels.Dish;
using RestaurantAPI.Core.Application.ViewModels.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModels.Order
{
    public class SaveOrderViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el subtotal.")]
        [DataType(DataType.Currency)]
        public double Subtotal { get; set; }
        public string Status { get; set; }
        public int TableId { get; set; }
        public TableViewModel Table { get; set; }
        public List<DishViewModel> Dishes { get; set; }
    }
}
