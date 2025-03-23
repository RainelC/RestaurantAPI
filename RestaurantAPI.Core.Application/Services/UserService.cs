
using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.Account;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.User;

namespace RestaurantAPI.Core.Application.Services
{
    public class UserService : IUserService
    {
        private IAccountService _accountService;
        private readonly IMapper _mapper;
        public UserService(IAccountService accountService, IMapper mapper)
        {
            accountService = _accountService;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel login)
        {
            AuthenticationRequest request = _mapper.Map<AuthenticationRequest>(login);
            return await _accountService.AuthenticationAsync(request);
        }

        public async Task<RegisterResponse> RegisterWaiterAsync(SaveUserViewModel vm)
        {
            RegisterRequest request = _mapper.Map<RegisterRequest>(vm);
            return await _accountService.RegisterWaiterUserAsync(request);
        }

        public async Task<RegisterResponse> RegisterAdminAsync(SaveUserViewModel vm)
        {
            RegisterRequest request = _mapper.Map<RegisterRequest>(vm);
            return await _accountService.RegisterAdminUserAsync(request);
        }
    }
}
