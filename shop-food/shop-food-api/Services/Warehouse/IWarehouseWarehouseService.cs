using Common.Model.Response;
using shop_food_api.Models.Warehouse;

namespace shop_food_api.Services.Warehouse
{
    public interface IWarehouseWarehouseService
    {
        Task<ApiResponse<WarehouseUpdateModelRes>> Update(WarehouseUpdateModelReq req);

        Task<ApiResponse<WarehouseCreateModelRes>> Create(WarehouseCreateModelReq req);

        Task<ApiResponse<WarehouseDeleteModelRes>> Delete(WarehouseDeleteModelReq req);

        Task<ApiResponse<WarehouseListModelRes>> List(WarehouseListModelReq req);
    }
}