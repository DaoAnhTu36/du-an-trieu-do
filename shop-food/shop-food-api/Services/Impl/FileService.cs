using System.Reflection;
using System.Security.AccessControl;
using Common.Model.Config;
using Microsoft.Extensions.Options;
using shop_food_api.Models.FileModels;
using utility;

namespace shop_food_api.Services.Impl
{
    public class FileService : IFileService
    {
        private readonly IOptions<AppConfig> _options;
        public FileService(IOptions<AppConfig> options)
        {
            _options = options;
        }
        public async Task<ApiResponse<UploadFileRequestDTO>> FileUpload(List<IFormFile> files)
        {
            var retVal = new ApiResponse<UploadFileRequestDTO>();
            try
            {
                var size = files.Sum(f => f.Length);
                var filePath = Directory.GetCurrentDirectory() + _options.Value.FolderSetting?.PathFolderMedia?.Trim();
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var pathSave = filePath + formFile.FileName;
                        using (var stream = new FileStream(pathSave, FileMode.OpenOrCreate))
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