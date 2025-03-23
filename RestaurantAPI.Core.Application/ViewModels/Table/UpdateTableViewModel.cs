using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Core.Application.ViewModels.Table
{
    public class UpdateTableViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar la cantidad de personas por mesa.")]
        public int CapacityPeople { get; set; }
        [Required(ErrorMessage = "Debe colocar la descripción de la mesa.")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
