using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model.Response;
using Microsoft.AspNetCore.Mvc;
using shop_food_api.Models.FileModels;
using shop_food_api.Services;

namespace shop_food_api.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<ApiResponse<UploadFileRequestDTO>> FileUpload(List<IFormFile> files)
        {
            return await _fileService.FileUpload(files);
        }

        [HttpPost("list")]
        public async Task<ApiResponse<List<ItemFileManagerResponseDTO>>> ListFileManager(ItemFileManagerRequestDTO request)
        {
            return await _fileService.ListFileManager(request);
        }
    }
}
