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
            return new ApiResponse<int>
            {
                Data = _queueService.GetQueueCount(),
            };
        }
    }
}