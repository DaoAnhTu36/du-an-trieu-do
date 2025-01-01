using Common.Model.Response;
using shop_food_authen.Contexts;

namespace shop_food_authen.Services
{
    public interface IAdminService
    {
        Task<ApiResponse<List<AdminInforResponseDTO>>> GetListAdmin(AdminInforRequestDTO instance);

        Task<ApiResponse<AdminSignInDTOResponse>> SignInAdmin(AdminSignInDTORequest instance);

        Task<ApiResponse> SignUpAdmin(AdminSignUpDTORequest instance);
    }
}