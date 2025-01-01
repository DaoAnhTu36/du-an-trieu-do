using Common.Model.Config;
using Common.Model.Response;
using Common.Utility;
using Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_food_api.DatabaseContext.Entities;
using shop_food_api.Models;

namespace shop_food_api.Services.Impl
{
    public class CategoryService : Repository<CategoryEntity>, ICategoryService
    {
        private readonly IOptions<AppConfig> _options;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork
            , DbContext context
            , IOptions<AppConfig> options) : base(context)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<ApiResponse> AddCategory(ApiCreateCategoryModelReq model)
        {
            _context.Add(new CategoryEntity
            {
                Name = model.Name,
                ParentId = model.ParentId,
                FileId = model.FileId,
            });
            await _unitOfWork.SaveChangesAsync();
            return new ApiResponse();
        }

        public async Task<ApiResponse<IEnumerable<ApiListCategoryModelRes>>> GetListCategory(int pageNum, int pageSize)
        {
            var retVal = new ApiResponse<IEnumerable<ApiListCategoryModelRes>>();
            var query = _context.Set<CategoryEntity>()
                .Join(_context.Set<FileManagerEntity>()
                , categories => categories.FileId
                , files => files.Id
                , (categories, files) => new ApiListCategoryModelRes
                {
                    Id = categories.Id,
                    Name = categories.Name,
                    ParentId = categories.ParentId,
                    FileName = files.Name,
                    FilePath = files.Path
                });

            retVal.Data = UtilityDatabase.PaginationExtension(_options, query, pageNum, pageSize);
            return retVal;
        }
    }
}