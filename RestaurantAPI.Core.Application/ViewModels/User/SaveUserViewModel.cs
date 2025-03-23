using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
    {
        [Required(ErrorMessage = "The firstname is required.")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The lastname is required.")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The PhoneNumber is required.")]
        [RegularExpression(@"\(\d{3}\)-\d{3}-\d{4}", ErrorMessage = "El formato debe ser (000)-000-0000.")]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "The Mail is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The UserName is required.")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden")]

        public string ConfirmPassword { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
