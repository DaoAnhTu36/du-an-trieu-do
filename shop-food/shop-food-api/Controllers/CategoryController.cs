using Common.Logger;
using Common.Model.Response;
using Microsoft.AspNetCore.Mvc;
using shop_food_api.Models;
using shop_food_api.Services;

namespace shop_food_api.Controllers
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add-new")]
        public async Task<ApiResponse> AddNewCategory([FromBody] ApiCreateCategoryModelReq model)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse();
            if (!ModelState.IsValid)
            {
                retVal = new ApiResponse
                {
                    IsNormal = false,
                    MetaData = new MetaData
                    {
                        Message = "Input is bad request",
                        StatusCode = "400"
                    }
                };
                LoggerFunctionUtility.CommonLogEnd(this, retVal);
                return retVal;
            }
            retVal = await _categoryService.AddCategory(model);
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }

        [HttpPost("list")]
        public async Task<ApiResponse<IEnumerable<ApiListCategoryModelRes>>> GetListCategory([FromBody] ApiListCategoryModelReq model)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<IEnumerable<ApiListCategoryModelRes>>();
            if (!ModelState.IsValid)
            {
                retVal.IsNormal = false;
                retVal.MetaData = new MetaData
                {
                    Message = "Input is bad request",
                    StatusCode = "400"
                };
                LoggerFunctionUtility.CommonLogEnd(this, retVal);
                return retVal;
            }
            retVal = await _categoryService.GetListCategory(model.PageNumber, model.PageSize);
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }
    }
}