using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop_food_api.Models.FileModels;
using utility;

namespace shop_food_api.Services
{
    public interface IFileService
    {
        Task<ApiResponse<UploadFileRequestDTO>> FileUpload(List<IFormFile> files);
    }
}
