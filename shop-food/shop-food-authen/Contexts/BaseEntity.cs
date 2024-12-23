using System.ComponentModel.DataAnnotations;

namespace shop_food_authen.Contexts
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "admin";
        public string UpdatedBy { get; set; } = "admin";
    }
}