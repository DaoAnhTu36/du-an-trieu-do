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
        public async Task<ApiResponse> SignUp(AdminSignUpDTORequest instance)
        {
            return await _service.SignUpAdmin(instance);
        }

        [HttpPost("sign-in")]
        public async Task<ApiResponse<AdminSignInDTOResponse>> SingIn(AdminSignInDTORequest instance)
        {
            return await _service.SignInAdmin(instance);
        }

        [HttpPost("get-list-admin")]
        public async Task<ApiResponse<List<AdminInforResponseDTO>>> GetListAdmin(AdminInforRequestDTO instance)
        {
            return await _service.GetListAdmin(instance);
        }
    }
}