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
    public class UnitWhService : Repository<UnitWhEntity>, IUnitWhService
    {
        private readonly IOptions<AppConfig> _options;
        private readonly IUnitOfWork _unitOfWork;

        public UnitWhService(IUnitOfWork unitOfWork
            , DbContext context
            , IOptions<AppConfig> options) : base(context)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<ApiResponse<UnitWhCreateModelRes>> Create(UnitWhCreateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<UnitWhCreateModelRes>();
            try
            {
                var record = await _context.Set<UnitWhEntity>().FirstOrDefaultAsync(x => x.Name == req.Name);
                if (record != null)
                {
                    retVal.IsNormal = true;
                    retVal.MetaData = new MetaData
                    {
                        Message = "Record existed",
                        StatusCode = "400"
                    };
                    LoggerFunctionUtility.CommonLogEnd(this, retVal);
                    return retVal;
                }
                var entity = new UnitWhEntity
                {
                    Name = req.Name,
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

        public async Task<ApiResponse<UnitWhDeleteModelRes>> Delete(UnitWhDeleteModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<UnitWhDeleteModelRes>();
            try
            {
                var entity = new UnitWhEntity { Id = req.Id };
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

        public async Task<ApiResponse<UnitWhListModelRes>> List(UnitWhListModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<UnitWhListModelRes>();
            try
            {
                var query = _context.Set<UnitWhEntity>()
                    .OrderByDescending(x => x.UpdatedDate)
                    .Select(x => new UnitWhModel
                    {
                        UpdatedDate = x.UpdatedDate,
                        UpdatedBy = x.UpdatedBy,
                        Id = x.Id,
                        CreatedDate = x.CreatedDate,
                        CreatedBy = x.CreatedBy,
                        Name = x.Name
                    });
                retVal = new ApiResponse<UnitWhListModelRes>
                {
                    Data = new UnitWhListModelRes
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

        public async Task<ApiResponse<UnitWhUpdateModelRes>> Update(UnitWhUpdateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<UnitWhUpdateModelRes>();
            try
            {
                var record = await _context.Set<UnitWhEntity>().FirstOrDefaultAsync(x => x.Id == req.Id);
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