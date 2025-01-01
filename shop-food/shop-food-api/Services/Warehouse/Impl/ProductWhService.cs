using Common.Logger;
using Common.Model.Config;
using Common.Model.Response;
using Common.User;
using Common.Utility;
using Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_food_api.DatabaseContext.Entities.Warehouse;
using shop_food_api.Models.Warehouse;

namespace shop_food_api.Services.Warehouse.Impl
{
    public class ProductWhService : Repository<ProductWhEntity>, IProductWhService
    {
        private readonly IOptions<AppConfig> _options;
        private readonly IUnitOfWork _unitOfWork;

        public ProductWhService(IUnitOfWork unitOfWork
            , DbContext context
            , IOptions<AppConfig> options) : base(context)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<ApiResponse<ProductWhCreateModelRes>> Create(ProductWhCreateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<ProductWhCreateModelRes>();
            try
            {
                var entity = new ProductWhEntity
                {
                    Name = req.Name,
                    Description = req.Description,
                };
                _context.Add(entity);
                await _unitOfWork.SaveChangesAsync();
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
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }

        public async Task<ApiResponse<ProductWhDeleteModelRes>> Delete(ProductWhDeleteModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<ProductWhDeleteModelRes>();
            try
            {
                var entity = new ProductWhEntity { Id = req.Id };
                _context.Entry(entity).State = EntityState.Deleted;
                await _unitOfWork.SaveChangesAsync();
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
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }

        public async Task<ApiResponse<ProductWhListModelRes>> List(ProductWhListModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<ProductWhListModelRes>();
            try
            {
                var query = _context.Set<ProductWhEntity>()
                    .OrderByDescending(x => x.UpdatedDate)
                    .Select(x => new ProductWhModel
                    {
                        UpdatedDate = x.UpdatedDate,
                        UpdatedBy = x.UpdatedBy,
                        Id = x.Id,
                        CreatedDate = x.CreatedDate,
                        CreatedBy = x.CreatedBy,
                        Name = x.Name,
                        Description = x.Description,
                    });
                retVal = new ApiResponse<ProductWhListModelRes>
                {
                    Data = new ProductWhListModelRes
                    {
                        List = UtilityDatabase.PaginationExtension(_options, query, req.PageNumber, req.PageSize)
                    }
                };
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
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }

        public async Task<ApiResponse<ProductWhUpdateModelRes>> Update(ProductWhUpdateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<ProductWhUpdateModelRes>();
            try
            {
                var record = await _context.Set<ProductWhEntity>().FirstOrDefaultAsync(x => x.Id == req.Id);
                if (record == null)
                {
                    retVal.IsNormal = false;
                    retVal.MetaData = new MetaData
                    {
                        Message = "NotFound",
                        StatusCode = "400"
                    };
                    LoggerFunctionUtility.CommonLogEnd(this, retVal);
                    return retVal;
                }
                record.Name = !string.IsNullOrEmpty(req.Name) ? req.Name : record.Name;
                record.Description = !string.IsNullOrEmpty(req.Description) ? req.Name : record.Description;
                record.UpdatedBy = AdminInfo.Id;
                record.UpdatedDate = DateTime.Now;
                _context.Update(record);
                await _unitOfWork.SaveChangesAsync();
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
            LoggerFunctionUtility.CommonLogEnd(this, retVal);
            return retVal;
        }
    }
}