using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities
{
    [Table("Product", Schema = "SHOP")]
    public class ProductEntity : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public Guid? FileId { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }

    }
}