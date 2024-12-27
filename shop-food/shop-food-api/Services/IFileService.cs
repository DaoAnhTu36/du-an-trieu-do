using Common.Model.Response;
using shop_food_api.Models;

namespace shop_food_api.Services
{
    public interface IFileService
    {
        Task<ApiResponse<UploadFileResponseDTO>> FileUpload(List<IFormFile> files);

        Task<ApiResponse<IEnumerable<ItemFileManagerResponseDTO>>> ListFileManager(ItemFileManagerRequestDTO request);
    }
}