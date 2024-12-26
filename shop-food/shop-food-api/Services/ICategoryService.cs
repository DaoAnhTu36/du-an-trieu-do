using Common.Model.Response;
using shop_food_api.Models;
using shop_food_api.Repositories;

namespace shop_food_api.Services
{
    public interface ICategoryService : ICategoryRepository
    {
        Task<ApiResponse> AddCategory(CategoryModelReq model);

        Task<ApiResponse<IEnumerable<CategoryModelRes>>> GetListCategory(int pageNum, int pageSize);
    }
}
