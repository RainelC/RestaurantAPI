using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
