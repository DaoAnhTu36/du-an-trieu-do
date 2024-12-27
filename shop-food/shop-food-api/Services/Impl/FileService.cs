using Common.Model.Config;
using Common.Model.Response;
using Common.Queue;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_food_api.DatabaseContext;
using shop_food_api.DatabaseContext.Entities;
using shop_food_api.Models;

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

        public async Task<ApiResponse<UploadFileResponseDTO>> FileUpload(List<IFormFile> files)
        {
            var retVal = new ApiResponse<UploadFileResponseDTO>
            {
                Data = new UploadFileResponseDTO
                {
                    FileIds = new List<FileUploadDTO>()
                }
            };
            try
            {
                var size = files.Sum(f => f.Length);
                var filePath = Directory.GetCurrentDirectory() + _options.Value.FolderSetting?.PathFolderMedia?.Trim();
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                QueueService queueService = new();
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var fileName = UtilityConvert.RenameFileUpload(formFile.FileName);
                        var pathSave = filePath + fileName;
                        var id = Guid.NewGuid();
                        using (var stream = new FileStream(pathSave, FileMode.OpenOrCreate))
                        {
                            await formFile.CopyToAsync(stream);
                            _dbContext.Add(new FileManagerEntity
                            {
                                Id = id,
                                Path = pathSave,
                                Name = fileName,
                            });
                            //UploadBasic.Upload(_options.Value.GoogleSettings.OAuth2.ClientId, _options.Value.GoogleSettings.OAuth2.ClientSecret, pathSave);
                        }

                        await _dbContext.SaveChangesAsync();
                        retVal.Data.FileIds.Add(new FileUploadDTO
                        {
                            FileId = id,
                            FileName = fileName
                        });
                        //queueService.Enqueue(async () =>
                        //{
                        //    var fileName = UtilityConvert.RenameFileUpload(formFile.FileName);
                        //    var pathSave = filePath + fileName;
                        //    using (var stream = new FileStream(pathSave, FileMode.OpenOrCreate))
                        //    {
                        //        await formFile.CopyToAsync(stream);
                        //        _dbContext.Add(new FileManagerEntity
                        //        {
                        //            Path = pathSave,
                        //            Name = fileName,
                        //        });
                        //        //UploadBasic.Upload(_options.Value.GoogleSettings.OAuth2.ClientId, _options.Value.GoogleSettings.OAuth2.ClientSecret, pathSave);
                        //    }
                        //    await _dbContext.SaveChangesAsync();
                        //});
                    }
                }
                //_ = Task.Run(queueService.ProcessQueueAsync).ConfigureAwait(false);
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

        //private async Task SaveFile(IFormFile formFile)
        //{
        //    var filePath = Directory.GetCurrentDirectory() + _options.Value.FolderSetting?.PathFolderMedia?.Trim();
        //    if (!Directory.Exists(filePath))
        //    {
        //        Directory.CreateDirectory(filePath);
        //    }
        //    var fileName = UtilityConvert.RenameFileUpload(formFile.FileName);
        //    var pathSave = filePath + fileName;
        //    using (var stream = new FileStream(pathSave, FileMode.OpenOrCreate))
        //    {
        //        await formFile.CopyToAsync(stream);
        //        _dbContext.Add(new FileManagerEntity
        //        {
        //            Path = pathSave,
        //            Name = fileName,
        //        });
        //        //UploadBasic.Upload(_options.Value.GoogleSettings.OAuth2.ClientId, _options.Value.GoogleSettings.OAuth2.ClientSecret, pathSave);
        //    }
        //    await _dbContext.SaveChangesAsync();
        //}

        public async Task<ApiResponse<IEnumerable<ItemFileManagerResponseDTO>>> ListFileManager(ItemFileManagerRequestDTO request)
        {
            var retVal = new ApiResponse<IEnumerable<ItemFileManagerResponseDTO>>();
            try
            {
                var query = _dbContext.FileManagerEntities.Select(x => new ItemFileManagerResponseDTO
                {
                    FileName = x.Name,
                    FilePath = x.Path
                });
                retVal.Data = UtilityDatabase.PaginationExtension(_options, query, request.PageNumber, request.PageSize);
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