using Common.Model.Response;
using shop_food_api.Models.Warehouse;

namespace shop_food_api.Services.Warehouse
{
    public interface ITransactionWhService
    {
        Task<ApiResponse<TransactionWhUpdateModelRes>> Update(TransactionWhUpdateModelReq req);

        Task<ApiResponse<TransactionWhCreateModelRes>> Create(TransactionWhCreateModelReq req);

        Task<ApiResponse<TransactionWhDeleteModelRes>> Delete(TransactionWhDeleteModelReq req);

        Task<ApiResponse<TransactionWhListModelRes>> List(TransactionWhListModelReq req);

        Task<ApiResponse<TransactionWhDetailModelRes>> Detail(TransactionWhDetailModelReq req);
    }
}