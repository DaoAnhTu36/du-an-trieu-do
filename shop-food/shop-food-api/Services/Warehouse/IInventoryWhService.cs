using Common.Model.Response;
using shop_food_api.Models.Warehouse;

namespace shop_food_api.Services.Warehouse
{
    public interface IInventoryWhService
    {
        Task<ApiResponse<InventoryWhUpdateModelRes>> Update(InventoryWhUpdateModelReq req);

        Task<ApiResponse<InventoryWhCreateModelRes>> Create(InventoryWhCreateModelReq req);

        Task<ApiResponse<InventoryWhDeleteModelRes>> Delete(InventoryWhDeleteModelReq req);

        Task<ApiResponse<InventoryWhListModelRes>> List(InventoryWhListModelReq req);
    }
}