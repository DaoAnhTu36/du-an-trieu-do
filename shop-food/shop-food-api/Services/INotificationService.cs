using Common.Model.Response;
using shop_food_api.Models;

namespace shop_food_api.Services
{
    public interface INotificationService
    {
        Task<ApiResponse<GetNotificationByUserIdModelRes>> GetNotificationByUserId(GetNotificationByUserIdModelReq req);
    }
}