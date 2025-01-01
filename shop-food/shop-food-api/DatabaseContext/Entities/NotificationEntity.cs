using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities
{
    [Table("Notification", Schema = "MD")]
    public class NotificationEntity : BaseEntity
    {
        public string? Title { get; set; }
        public string? Body { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsForAnyone { get; set; }
    }
}
