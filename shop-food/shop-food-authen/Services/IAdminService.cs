using shop_food_authen.Contexts;
using utility;

namespace shop_food_authen.Services
{
    public interface IAdminService
    {
        Task<ApiResponse> SignUpAdmin(AdminDTORequest instance);
    }
}