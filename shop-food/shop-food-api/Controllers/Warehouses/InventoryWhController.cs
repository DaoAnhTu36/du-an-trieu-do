using Common.Logger;
using Common.Model.Response;
using Microsoft.AspNetCore.Mvc;
using shop_food_api.Models.Warehouse;
using shop_food_api.Services.Warehouse;

namespace shop_food_api.Controllers.Warehouses
{
    [Route("api/warehouse/inventory")]
    public class InventoryWhController : Controller
    {
        private readonly IInventoryWhService _service;

        public InventoryWhController(IInventoryWhService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<ApiResponse<InventoryWhCreateModelRes>> Create([FromBody] InventoryWhCreateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<InventoryWhCreateModelRes>();
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
            retVal = await _service.Create(req);
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }

        [HttpPost("update")]
        public async Task<ApiResponse<InventoryWhUpdateModelRes>> Update([FromBody] InventoryWhUpdateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<InventoryWhUpdateModelRes>();
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
            retVal = await _service.Update(req);
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }

        [HttpPost("delete")]
        public async Task<ApiResponse<InventoryWhDeleteModelRes>> Delete([FromBody] InventoryWhDeleteModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<InventoryWhDeleteModelRes>();
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
            retVal = await _service.Delete(req);
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }

        [HttpPost("list")]
        public async Task<ApiResponse<InventoryWhListModelRes>> List([FromBody] InventoryWhListModelReq req)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            LoggerFunctionUtility.CommonLogStart(this, stopwatch);
            var retVal = new ApiResponse<InventoryWhListModelRes>();
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
            retVal = await _service.List(req);
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }
    }
}