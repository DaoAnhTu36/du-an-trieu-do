using Common.Logger;
using Common.Model.Config;
using Common.Model.Response;
using Common.Utility;
using Core.EF;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_food_api.DatabaseContext.Entities;
using shop_food_api.Models;
using shop_food_api.SignalR;

namespace shop_food_api.Services.Impl
{
    public class NotificationService : Repository<NotificationEntity>, INotificationService
    {
        private readonly IOptions<AppConfig> _options;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IUnitOfWork unitOfWork
            , DbContext context
            , IOptions<AppConfig> options
            , IHubContext<NotificationHub> hubContext) : base(context)
        {
            _unitOfWork = unitOfWork;
            _options = options;
            _hubContext = hubContext;
        }

        public async Task<ApiResponse<CreateNotificationModelRes>> CreateNotification(CreateNotificationModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<CreateNotificationModelRes>();
            try
            {
                var entity = new NotificationEntity
                {
                    Body = req.Body,
                    Title = req.Title,
                    UserId = req.UserId,
                    IsForAnyone = req.IsForAnyone,
                };
                _context.Add(entity);
                await _unitOfWork.SaveChangesAsync();
                _ = Task.Run(async () =>
                {
                    await SendMessageSignalR(new Dictionary<string, object>
                    {
                        {"Title",req.Title??""},
                        {"Body",req.Body??""},
                        {"CreatedDate",UtilityConvert.ConvertDatetimeToString(entity.CreatedDate)??""},
                    });
                });
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

        public async Task<ApiResponse<GetNotificationByUserIdModelRes>> GetNotificationByUserId(GetNotificationByUserIdModelReq req)
        {
            LoggerFunctionUtility.CommonLogStart(this);
            var retVal = new ApiResponse<GetNotificationByUserIdModelRes>();
            try
            {
                var query = _context.Set<NotificationEntity>()
                    .OrderByDescending(x => x.UpdatedDate)
                    .Select(x => new NotificationModels
                    {
                        Id = x.Id,
                        Body = x.Body,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        Title = x.Title,
                        UpdatedBy = x.UpdatedBy,
                        UpdatedDate = x.UpdatedDate,
                        UserId = x.UserId
                    });
                retVal = new ApiResponse<GetNotificationByUserIdModelRes>
                {
                    Data = new GetNotificationByUserIdModelRes
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

        public async Task SendMessageSignalR(Dictionary<string, object> req)
        {
            await _hubContext.Clients.All.SendAsync("SendMessageFromServerToClient", UtilityConvert.SerializeObject(req));
        }
    }
}