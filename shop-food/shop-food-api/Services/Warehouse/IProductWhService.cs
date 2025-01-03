using Common.Model.Response;
using shop_food_api.Models.Warehouse;

namespace shop_food_api.Services.Warehouse
{
    public interface IProductWhService
    {
        Task<ApiResponse<ProductWhUpdateModelRes>> Update(ProductWhUpdateModelReq req);

        Task<ApiResponse<ProductWhCreateModelRes>> Create(ProductWhCreateModelReq req);

        Task<ApiResponse<ProductWhDeleteModelRes>> Delete(ProductWhDeleteModelReq req);

        Task<ApiResponse<ProductWhListModelRes>> List(ProductWhListModelReq req);

        Task<ApiResponse<ProductWhDetailModelRes>> Detail(ProductWhDetailModelReq req);
    }
}