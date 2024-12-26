using shop_food_api.Models.FileModels;
using utility;

namespace shop_food_api.Services
{
    public interface IFileService
    {
        Task<ApiResponse<UploadFileRequestDTO>> FileUpload(List<IFormFile> files);

        Task<ApiResponse<List<ItemFileManagerResponseDTO>>> ListFileManager(ItemFileManagerRequestDTO request);
    }
}