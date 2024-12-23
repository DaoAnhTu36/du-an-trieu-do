using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_food_authen.Contexts;
using utility;

namespace shop_food_authen.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController() { }

        [HttpPost()]
        public async Task<ApiResponse> SignUp(AdminDTORequest instance)
        {

        }
    }
}
