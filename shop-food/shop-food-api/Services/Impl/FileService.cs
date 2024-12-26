using Common.Google;
using Common.Model.Config;
using Common.Model.Response;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_food_api.DatabaseContext;
using shop_food_api.DatabaseContext.Entities;
using shop_food_api.Models.FileModels;

namespace shop_food_api.Services.Impl
{
    public class FileService : IFileService
    {
        private readonly IOptions<AppConfig> _options;
        private readonly EntityDBContext _dbContext;

        public FileService(IOptions<AppConfig> options
            , EntityDBContext dbContext)
        {
            _options = options;
            _dbContext = dbContext;
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
                            _dbContext.Add(new FileManagerEntity
                            {
                                Path = pathSave,
                                Name = formFile.FileName,
                            });
                            UploadBasic.Upload(_options.Value.GoogleSettings.OAuth2.ClientId, _options.Value.GoogleSettings.OAuth2.ClientSecret, pathSave);
                        }
                    }
                }
                await _dbContext.SaveChangesAsync();
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

        public async Task<ApiResponse<List<ItemFileManagerResponseDTO>>> ListFileManager(ItemFileManagerRequestDTO request)
        {
            var retVal = new ApiResponse<List<ItemFileManagerResponseDTO>>();
            try
            {
                var query = await _dbContext.FileManagerEntities.Select(x => new ItemFileManagerResponseDTO
                {
                    FileName = x.Name,
                    FilePath = x.Path
                }).ToListAsync();
                retVal.Data = UtiDatabase.PaginationExtension(_options, query, request.PageNumber, request.PageSize);
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