using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Dtos.Account;
using RestaurantAPI.Core.Application.Interfaces.Services;

namespace RestaurantAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            var response = await _accountService.AuthenticationAsync(request);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);
        }

        [HttpPost("register-admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdminUserAsync(RegisterRequest request)
        {
            var response = await _accountService.RegisterAdminUserAsync(request);
            if (response == null)
                return BadRequest(new { message = "User registration failed" });
            return Ok(response);
        }

        [HttpPost("register-waiter")]
        public async Task<IActionResult> RegisterWaiterUserAsync(RegisterRequest request)
        {
            var response = await _accountService.RegisterWaiterUserAsync(request);
            if (response == null)
                return BadRequest(new { message = "User registration failed" });
            return Ok(response);
        }

    }
}
