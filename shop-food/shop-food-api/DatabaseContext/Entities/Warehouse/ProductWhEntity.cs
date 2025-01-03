using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("Product", Schema = "WH")]
    public class ProductWhEntity : BaseEntity
    {
        public string? BarCode { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid SupplierId { get; set; }
        public Guid UnitId { get; set; }
    }
}