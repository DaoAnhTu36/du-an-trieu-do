using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logger;
using Common.Model.Response;
using Microsoft.AspNetCore.Mvc;
using shop_food_api.Models;
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
        public async Task<ApiResponse<UploadFileResponseDTO>> FileUpload(List<IFormFile> files)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<UploadFileResponseDTO>();
            try
            {
                retVal = await _fileService.FileUpload(files);
            }
            catch (Exception ex)
            {
                retVal = new ApiResponse<UploadFileResponseDTO>
                {
                    IsNormal = false,
                    MetaData = new MetaData
                    {
                        Message = ex.Message,
                        StatusCode = "500",
                        ExceptionExtra = ex
                    }
                };
                LoggerFunctionUtility.CommonLogEnd(this, retVal);
            }
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }

        [HttpPost("list")]
        public async Task<ApiResponse<IEnumerable<ItemFileManagerResponseDTO>>> ListFileManager(ItemFileManagerRequestDTO request)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<IEnumerable<ItemFileManagerResponseDTO>>();
            try
            {
                retVal = await _fileService.ListFileManager(request);
            }
            catch (Exception ex)
            {
                retVal = new ApiResponse<IEnumerable<ItemFileManagerResponseDTO>>
                {
                    IsNormal = false,
                    MetaData = new MetaData
                    {
                        Message = ex.Message,
                        StatusCode = "500",
                        ExceptionExtra = ex
                    }
                };
                LoggerFunctionUtility.CommonLogEnd(this, retVal);
            }
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }
    }
}