using Common.Model.Response;
using Microsoft.AspNetCore.Mvc;
using shop_food_api.Models.Warehouse;
using shop_food_api.Services.Warehouse;

namespace shop_food_api.Controllers.Warehouses
{
    [Route("api/warehouse/warehouse")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseWarehouseService _service;

        public WarehouseController(IWarehouseWarehouseService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<ApiResponse<WarehouseCreateModelRes>> Create([FromBody] WarehouseCreateModelReq req)
        {
            var className = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            var methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
            var retVal = new ApiResponse<WarehouseCreateModelRes>();
            if (!ModelState.IsValid)
            {
                retVal.IsNormal = false;
                retVal.MetaData = new MetaData
                {
                    Message = "Model invalid",
                    StatusCode = "400"
                };
                return retVal;
            }
            return await _service.Create(req);
        }

        [HttpPost("update")]
        public async Task<ApiResponse<WarehouseUpdateModelRes>> Update([FromBody] WarehouseUpdateModelReq req)
        {
            var className = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            var methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
            var retVal = new ApiResponse<WarehouseUpdateModelRes>();
            if (!ModelState.IsValid)
            {
                retVal.IsNormal = false;
                retVal.MetaData = new MetaData
                {
                    Message = "Model invalid",
                    StatusCode = "400"
                };
                return retVal;
            }
            return await _service.Update(req);
        }

        [HttpPost("delete")]
        public async Task<ApiResponse<WarehouseDeleteModelRes>> Delete([FromBody] WarehouseDeleteModelReq req)
        {
            var className = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            var methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
            var retVal = new ApiResponse<WarehouseDeleteModelRes>();
            if (!ModelState.IsValid)
            {
                retVal.IsNormal = false;
                retVal.MetaData = new MetaData
                {
                    Message = "Model invalid",
                    StatusCode = "400"
                };
                return retVal;
            }
            return await _service.Delete(req);
        }


        [HttpPost("list")]
        public async Task<ApiResponse<WarehouseListModelRes>> List([FromBody] WarehouseListModelReq req)
        {
            var className = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            var methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
            var retVal = new ApiResponse<WarehouseListModelRes>();
            if (!ModelState.IsValid)
            {
                retVal.IsNormal = false;
                retVal.MetaData = new MetaData
                {
                    Message = "Model invalid",
                    StatusCode = "400"
                };
                return retVal;
            }
            return await _service.List(req);
        }
    }
}