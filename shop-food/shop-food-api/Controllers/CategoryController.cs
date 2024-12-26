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
        public async Task<ApiResponse> AddNewCategory([FromBody] CategoryModelReq model)
        {
            if (!ModelState.IsValid)
            {
                return new ApiResponse
                {
                    IsNormal = false,
                    MetaData = new MetaData
                    {
                        Message = "Input is bad request",
                        StatusCode = "400"
                    }
                };
            }
            return await _categoryService.AddCategory(model);
        }

        [HttpPost("list")]
        public async Task<ApiResponse<IEnumerable<CategoryModelRes>>> GetListCategory([FromBody] ListCategoryModelReq model)
        {
            var retVal = new ApiResponse<IEnumerable<CategoryModelRes>>();
            if (!ModelState.IsValid)
            {
                retVal.IsNormal = false;
                retVal.MetaData = new MetaData
                {
                    Message = "Input is bad request",
                    StatusCode = "400"
                };
                return retVal;
            }
            return await _categoryService.GetListCategory(model.PageNumber, model.PageSize);
        }
    }
}