using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities
{
    [Table("Category", Schema = "SHOP")]
    public class CategoryEntity : BaseEntity
    {
        public Guid? ParentId { get; set; }

        [Required]
        public string? Name { get; set; }

        public Guid? FileId { get; set; }
    }
}