using Common.Logger;
using Common.Model.Response;
using Microsoft.AspNetCore.Mvc;
using shop_food_api.Models.Warehouse;
using shop_food_api.Services.Warehouse;

namespace shop_food_api.Controllers.Warehouses
{
    [Route("api/wh/warehouse")]
    public class WarehouseWhController : Controller
    {
        private readonly IWarehouseWhService _service;

        public WarehouseWhController(IWarehouseWhService service)
        {
            _service = service;
        }

        [HttpPost("create-warehouse")]
        public async Task<ApiResponse<WarehouseCreateModelRes>> Create([FromBody] WarehouseCreateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<WarehouseCreateModelRes>();
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

        [HttpPost("update-warehouse")]
        public async Task<ApiResponse<WarehouseUpdateModelRes>> Update([FromBody] WarehouseUpdateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<WarehouseUpdateModelRes>();
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

        [HttpPost("delete-warehouse")]
        public async Task<ApiResponse<WarehouseDeleteModelRes>> Delete([FromBody] WarehouseDeleteModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<WarehouseDeleteModelRes>();
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

        [HttpPost("list-warehouse")]
        public async Task<ApiResponse<WarehouseListModelRes>> List([FromBody] WarehouseListModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<WarehouseListModelRes>();
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

        [HttpPost("get-warehouse-by-id")]
        public async Task<ApiResponse<WarehouseWhDetailByIdModelRes>> DetailById([FromBody] WarehouseWhDetailByIdModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<WarehouseWhDetailByIdModelRes>();
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
            retVal = await _service.DetailById(req);
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }

        [HttpPost("detail-warehouse")]
        public async Task<ApiResponse<WarehouseWhDetailModelRes>> Detail([FromBody] WarehouseWhDetailModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<WarehouseWhDetailModelRes>();
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
            retVal = await _service.Detail(req);
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }
    }
}