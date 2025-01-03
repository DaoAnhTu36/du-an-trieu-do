using Common.Logger;
using Common.Model.Config;
using Common.Model.Response;
using Common.User;
using Common.Utility;
using Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using shop_food_api.DatabaseContext.Entities;
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
                var recordByBarCode = await _context.Set<ProductWhEntity>().FirstOrDefaultAsync(x => x.BarCode == req.BarCode);
                if (recordByBarCode != null)
                {
                    retVal.IsNormal = false;
                    retVal.MetaData = new MetaData
                    {
                        Message = "Record exist",
                        StatusCode = "400"
                    };
                    LoggerFunctionUtility.CommonLogEnd(this, retVal);
                    return retVal;
                }
                var entity = new ProductWhEntity
                {
                    Name = req.Name,
                    Description = req.Description,
                    SupplierId = req.SupplierId,
                    UnitId = req.UnitId,
                    BarCode = req.BarCode,
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

        public async Task<ApiResponse<ProductWhDetailModelRes>> Detail(ProductWhDetailModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<ProductWhDetailModelRes>();

            try
            {
                var query = await (from products in _context.Set<ProductWhEntity>()
                                   where products.Id == req.Id || products.BarCode == req.BarCode
                                   join supplier in _context.Set<SupplierWhEntity>() on products.SupplierId equals supplier.Id
                                   join unit in _context.Set<UnitWhEntity>() on products.UnitId equals unit.Id
                                   select new ProductWhDetailModelRes
                                   {
                                       UnitId = unit.Id,
                                       SupplierId = supplier.Id,
                                       Id = products.Id,
                                       CreatedBy = products.CreatedBy,
                                       CreatedDate = products.CreatedDate,
                                       Description = products.Description,
                                       Name = products.Name,
                                       SupplierName = supplier.Name,
                                       UnitName = unit.Name,
                                       UpdatedBy = products.UpdatedBy,
                                       UpdatedDate = products.UpdatedDate,
                                       BarCode = products.BarCode,
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

        public async Task<ApiResponse<ProductWhListModelRes>> List(ProductWhListModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<ProductWhListModelRes>();
            try
            {
                var query = (from products in _context.Set<ProductWhEntity>()
                             join supplier in _context.Set<SupplierWhEntity>() on products.SupplierId equals supplier.Id
                             join unit in _context.Set<UnitWhEntity>() on products.UnitId equals unit.Id
                             select new ProductWhModel
                             {
                                 UnitId = unit.Id,
                                 SupplierId = supplier.Id,
                                 Id = products.Id,
                                 CreatedBy = products.CreatedBy,
                                 CreatedDate = products.CreatedDate,
                                 Description = products.Description,
                                 Name = products.Name,
                                 SupplierName = supplier.Name,
                                 UnitName = unit.Name,
                                 UpdatedBy = products.UpdatedBy,
                                 UpdatedDate = products.UpdatedDate,
                                 BarCode = products.BarCode,
                             }).OrderByDescending(x => x.UpdatedDate).AsQueryable();
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
                record.UnitId = req.UnitId != Guid.Empty ? req.UnitId : record.UnitId;
                record.SupplierId = req.SupplierId != Guid.Empty ? req.SupplierId : record.SupplierId;
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