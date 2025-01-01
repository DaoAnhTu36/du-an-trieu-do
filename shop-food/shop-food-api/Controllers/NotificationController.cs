using Common.Logger;
using Common.Model.Response;
using Microsoft.AspNetCore.Mvc;
using shop_food_api.Models;
using shop_food_api.Models.Warehouse;
using shop_food_api.Services;

namespace shop_food_api.Controllers
{
    [Route("api/notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpPost("notification-by-user-id")]
        public async Task<ApiResponse<GetNotificationByUserIdModelRes>> GetNotificationByUserId([FromBody] GetNotificationByUserIdModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<GetNotificationByUserIdModelRes>();
            if (!ModelState.IsValid)
            {
                retVal.IsNormal = false;
                retVal.MetaData = new MetaData
                {
                    Message = "Model invalid",
                    StatusCode = "400"
                };
                LoggerFunctionUtility.CommonLogEnd(this, retVal);
                return retVal;
            }
            retVal = await _service.GetNotificationByUserId(req);
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }

        [HttpPost("create-notification")]
        public async Task<ApiResponse<CreateNotificationModelRes>> CreateNotification([FromBody] CreateNotificationModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<CreateNotificationModelRes>();
            if (!ModelState.IsValid)
            {
                retVal.IsNormal = false;
                retVal.MetaData = new MetaData
                {
                    Message = "Model invalid",
                    StatusCode = "400"
                };
                LoggerFunctionUtility.CommonLogEnd(this, retVal);
                return retVal;
            }
            retVal = await _service.CreateNotification(req);
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }
    }
}