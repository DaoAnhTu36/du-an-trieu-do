using Common.Logger;
using Common.Model.Response;
using Microsoft.AspNetCore.Mvc;
using shop_food_api.Models.Warehouse;
using shop_food_api.Services.Warehouse;

namespace shop_food_api.Controllers.Warehouses
{
    [Route("api/wh/supplier")]
    public class SupplierWhController : Controller
    {
        private readonly ISupplierWhService _service;

        public SupplierWhController(ISupplierWhService service)
        {
            _service = service;
        }

        [HttpPost("create-supplier")]
        public async Task<ApiResponse<SupplierWhCreateModelRes>> Create([FromBody] SupplierWhCreateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<SupplierWhCreateModelRes>();
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

        [HttpPost("update-supplier")]
        public async Task<ApiResponse<SupplierWhUpdateModelRes>> Update([FromBody] SupplierWhUpdateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<SupplierWhUpdateModelRes>();
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

        [HttpPost("delete-supplier")]
        public async Task<ApiResponse<SupplierWhDeleteModelRes>> Delete([FromBody] SupplierWhDeleteModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<SupplierWhDeleteModelRes>();
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

        [HttpPost("list-supplier")]
        public async Task<ApiResponse<SupplierWhListModelRes>> List([FromBody] SupplierWhListModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this, req);
            var retVal = new ApiResponse<SupplierWhListModelRes>();
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