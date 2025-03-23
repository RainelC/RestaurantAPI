using RestaurantAPI.Core.Application.Dtos.Account;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticationAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterAdminUserAsync(RegisterRequest request);
        Task<RegisterResponse> RegisterWaiterUserAsync(RegisterRequest request);
    }
}