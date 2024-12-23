using Microsoft.AspNetCore.Mvc;
using shop_food_authen.Contexts;
using shop_food_authen.Services;
using utility;

namespace shop_food_authen.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpPost("sign-up")]
        public async Task<ApiResponse> SignUp(AdminDTORequest instance)
        {
            return await _service.SignUpAdmin(instance);
        }
    }
}