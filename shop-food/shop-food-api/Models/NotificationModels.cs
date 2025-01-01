using Common.Model.Entitties;
using shop_food_api.DatabaseContext.Entities;

namespace shop_food_api.Models
{
    public class NotificationModels : NotificationEntity
    {
    }

    public class GetNotificationByUserIdModelReq : BasePageEntity
    {
    }

    public class GetNotificationByUserIdModelRes 
    {
        public IEnumerable<NotificationModels> List { get; set; }
    }
}