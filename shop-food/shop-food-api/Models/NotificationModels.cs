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

    public class CreateNotificationModelReq
    {
        public string? Title { get; set; }
        public string? Body { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsForAnyone { get; set; }
    }

    public class CreateNotificationModelRes
    {
    }
}