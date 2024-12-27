using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("Product", Schema = "WH")]
    public class ProductWhEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}