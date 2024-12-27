using Common.Model.Response;
using Common.Queue;
using Microsoft.AspNetCore.Mvc;

namespace shop_food_api.Controllers
{
    [Route("api/queue")]
    public class QueueController : Controller
    {
        private readonly QueueService _queueService;

        public QueueController()
        {
            _queueService = new QueueService();
        }

        [HttpGet("get-count")]
        public ApiResponse<int> GetCountQueue()
        {
            var className = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            var methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
            return new ApiResponse<int>
            {
                Data = _queueService.GetQueueCount(),
            };
        }
    }
}