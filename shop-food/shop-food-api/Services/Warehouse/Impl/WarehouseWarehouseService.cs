using Common.Model.Config;
using Common.Model.Response;
using Common.Utility;
using Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_food_api.DatabaseContext.Entities.Warehouse;
using shop_food_api.Models.Warehouse;

namespace shop_food_api.Services.Warehouse.Impl
{
    public class WarehouseWarehouseService : Repository<WarehouseEntity>, IWarehouseWarehouseService
    {
        private readonly IOptions<AppConfig> _options;
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseWarehouseService(IUnitOfWork unitOfWork
            , DbContext context
            , IOptions<AppConfig> options) : base(context)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<ApiResponse<WarehouseCreateModelRes>> Create(WarehouseCreateModelReq req)
        {
            var className = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            var methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
            var retVal = new ApiResponse<WarehouseCreateModelRes>();

            try
            {
                _context.Add(new WarehouseWarehouseEntity
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
            return retVal;
        }

        public async Task<ApiResponse<WarehouseDeleteModelRes>> Delete(WarehouseDeleteModelReq req)
        {
            var className = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            var methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
            var retVal = new ApiResponse<WarehouseDeleteModelRes>();

            try
            {
                var entity = new WarehouseWarehouseEntity { Id = req.Id };
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
            return retVal;
        }

        public async Task<ApiResponse<WarehouseListModelRes>> List(WarehouseListModelReq req)
        {
            var className = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            var methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
            var retVal = new ApiResponse<WarehouseListModelRes>();

            try
            {
                var query = _context.Set<WarehouseWarehouseEntity>()
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
            return retVal;
        }

        public async Task<ApiResponse<WarehouseUpdateModelRes>> Update(WarehouseUpdateModelReq req)
        {
            var className = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            var methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
            var retVal = new ApiResponse<WarehouseUpdateModelRes>();
            try
            {
                var entity = new WarehouseWarehouseEntity
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
            return retVal;
        }
    }
}