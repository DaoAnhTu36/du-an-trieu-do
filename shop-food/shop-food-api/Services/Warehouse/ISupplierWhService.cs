using Common.Model.Response;
using shop_food_api.Models.Warehouse;

namespace shop_food_api.Services.Warehouse
{
    public interface ISupplierWhService
    {
        Task<ApiResponse<SupplierWhUpdateModelRes>> Update(SupplierWhUpdateModelReq req);

        Task<ApiResponse<SupplierWhCreateModelRes>> Create(SupplierWhCreateModelReq req);

        Task<ApiResponse<SupplierWhDeleteModelRes>> Delete(SupplierWhDeleteModelReq req);

        Task<ApiResponse<SupplierWhListModelRes>> List(SupplierWhListModelReq req);

        Task<ApiResponse<SupplierWhDetailModelRes>> Detail(SupplierWhDetailModelReq req);
    }
}