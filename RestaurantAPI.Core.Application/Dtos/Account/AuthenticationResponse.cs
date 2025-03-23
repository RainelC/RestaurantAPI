using System.Text.Json.Serialization;

namespace RestaurantAPI.Core.Application.Dtos.Account
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public string JWTtoken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
