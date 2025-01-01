using Common.Logger;
using Common.Model.Config;
using Common.Model.Response;
using Common.Utility;
using Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_food_api.DatabaseContext.Entities;
using shop_food_api.DatabaseContext.Entities.Warehouse;
using shop_food_api.Models.Warehouse;

namespace shop_food_api.Services.Warehouse.Impl
{
    public class WarehouseWhService : Repository<WarehouseWhEntity>, IWarehouseWhService
    {
        private readonly IOptions<AppConfig> _options;
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseWhService(IUnitOfWork unitOfWork
            , DbContext context
            , IOptions<AppConfig> options) : base(context)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<ApiResponse<WarehouseCreateModelRes>> Create(WarehouseCreateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<WarehouseCreateModelRes>();

            try
            {
                _context.Add(new WarehouseWhEntity
                {
                    Address = req.Address,
                    Name = req.Name,
                });
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

        public async Task<ApiResponse<WarehouseDeleteModelRes>> Delete(WarehouseDeleteModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<WarehouseDeleteModelRes>();

            try
            {
                var entity = new WarehouseWhEntity { Id = req.Id };
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

        public async Task<ApiResponse<WarehouseWhDetailModelRes>> Detail(WarehouseWhDetailModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<WarehouseWhDetailModelRes>();

            try
            {
                var query = await _context.Set<WarehouseWhEntity>().Where(x => x.Id == req.Id).Select(x => new WarehouseWhDetailModelRes
                {
                    Id = x.Id,
                    Address = x.Address,
                    Name = x.Name,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate 
                }).FirstOrDefaultAsync();
                if (query == null)
                {
                    retVal.MetaData = new MetaData
                    {
                        Message = "NotFound",
                        StatusCode = "400"
                    };
                    LoggerFunctionUtility.CommonLogEnd(this, retVal);
                    return retVal;
                }
                retVal.Data = query;
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

        public async Task<ApiResponse<WarehouseWhDetailByIdModelRes>> DetailById(WarehouseWhDetailByIdModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<WarehouseWhDetailByIdModelRes>();

            try
            {
                var query = await _context.Set<WarehouseWhEntity>().Where(x => x.Id == req.Id).Select(x => new WarehouseWhDetailByIdModelRes
                {
                    Id = x.Id,
                    Address = x.Address,
                    Name = x.Name,
                }).FirstOrDefaultAsync();
                if (query == null)
                {
                    retVal.MetaData = new MetaData
                    {
                        Message = "NotFound",
                        StatusCode = "400"
                    };
                    LoggerFunctionUtility.CommonLogEnd(this, retVal);
                    return retVal;
                }
                retVal.Data = query;
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

        public async Task<ApiResponse<WarehouseListModelRes>> List(WarehouseListModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<WarehouseListModelRes>();

            try
            {
                var query = _context.Set<WarehouseWhEntity>()
                    .OrderByDescending(x => x.UpdatedDate)
                    .Select(x => new WarehouseInfoModel
                    {
                        Address = x.Address,
                        Id = x.Id,
                        Name = x.Name
                    });
                retVal = new ApiResponse<WarehouseListModelRes>
                {
                    Data = new WarehouseListModelRes
                    {
                        ListWarehouse = UtilityDatabase.PaginationExtension(_options, query, req.PageNumber, req.PageSize)
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

        public async Task<ApiResponse<WarehouseUpdateModelRes>> Update(WarehouseUpdateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<WarehouseUpdateModelRes>();
            try
            {
                var entity = new WarehouseWhEntity
                {
                    Id = req.Id,
                    Address = req.Address,
                    Name = req.Name
                };
                _context.Entry(entity).State = EntityState.Modified;
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