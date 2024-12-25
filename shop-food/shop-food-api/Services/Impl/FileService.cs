﻿using System.Reflection;
using System.Security.AccessControl;
using shop_food_api.Models.FileModels;
using utility;

namespace shop_food_api.Services.Impl
{
    public class FileService : IFileService
    {
        public async Task<ApiResponse<UploadFileRequestDTO>> FileUpload(List<IFormFile> files)
        {
            var retVal = new ApiResponse<UploadFileRequestDTO>();
            try
            {
                var size = files.Sum(f => f.Length);
                var filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location + "\\Media\\Images");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retVal.IsNormal = false;
                retVal.MetaData = new MetaData
                {
                    Message = ex.Message,
                    StatusCode = "500"
                };
            }
            return retVal;
        }
    }
}