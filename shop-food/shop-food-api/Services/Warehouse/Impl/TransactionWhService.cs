using Common.Logger;
using Common.Model.Config;
using Common.Model.Response;
using Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_food_api.DatabaseContext.Entities.Warehouse;
using shop_food_api.Models.Warehouse;

namespace shop_food_api.Services.Warehouse.Impl
{
    public class TransactionWhService : Repository<TransactionWhEntity>, ITransactionWhService
    {
        private readonly IOptions<AppConfig> _options;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionWhService(IUnitOfWork unitOfWork
            , DbContext context
            , IOptions<AppConfig> options) : base(context)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<ApiResponse<TransactionWhCreateModelRes>> Create(TransactionWhCreateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<TransactionWhCreateModelRes>();
            try
            {
                using var transactionDB = await _context.Database.BeginTransactionAsync();

                var transId = Guid.NewGuid();
                _context.Add(new TransactionWhEntity
                {
                    Id = transId,
                    TransactionType = req.TransactionType,
                    TransactionDate = req.TransactionDate,
                    TotalPrice = req.TotalPrice,
                    TransactionCode = req.TransactionCode,
                    
                });

                if (req.Details != null)
                {
                    foreach (var transaction in req.Details)
                    {
                        _context.Add(new TransactionDetailWhEntity
                        {
                            UnitPrice = transaction.UnitPrice,
                            DateOfExpired = transaction.DateOfExpired,
                            DateOfManufacture = transaction.DateOfManufacture,
                            ProductId = transaction.ProductId,
                            Quantity = transaction.Quantity,
                            TransactionId = transId,
                            TotalPrice = transaction.TotalPrice,
                        });
                    }
                }
                await _unitOfWork.SaveChangesAsync();

                await transactionDB.CommitAsync();
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

        public async Task<ApiResponse<TransactionWhDeleteModelRes>> Delete(TransactionWhDeleteModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<TransactionWhDeleteModelRes>();
            try
            {
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

        public async Task<ApiResponse<TransactionWhDetailModelRes>> Detail(TransactionWhDetailModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<TransactionWhDetailModelRes>();

            try
            {
                var query = await _context.Set<TransactionWhEntity>().Where(x => x.Id == req.Id).Select(x => new TransactionWhDetailModelRes
                {
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

        public async Task<ApiResponse<TransactionWhListModelRes>> List(TransactionWhListModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<TransactionWhListModelRes>();
            try
            {
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

        public async Task<ApiResponse<TransactionWhUpdateModelRes>> Update(TransactionWhUpdateModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<TransactionWhUpdateModelRes>();
            try
            {
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