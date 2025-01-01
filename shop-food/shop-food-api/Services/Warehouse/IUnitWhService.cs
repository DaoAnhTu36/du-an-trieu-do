using Common.Model.Response;
using shop_food_api.Models.Warehouse;

namespace shop_food_api.Services.Warehouse
{
    public interface IUnitWhService
    {
        Task<ApiResponse<UnitWhUpdateModelRes>> Update(UnitWhUpdateModelReq req);

        Task<ApiResponse<UnitWhCreateModelRes>> Create(UnitWhCreateModelReq req);

        Task<ApiResponse<UnitWhDeleteModelRes>> Delete(UnitWhDeleteModelReq req);

        Task<ApiResponse<UnitWhListModelRes>> List(UnitWhListModelReq req);
    }
}