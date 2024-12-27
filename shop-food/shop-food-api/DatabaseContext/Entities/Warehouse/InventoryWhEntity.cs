using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Configs;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("Inventory", Schema = ConfigSchemaTableDatabase.WH)]
    public class InventoryWhEntity : BaseEntity
    {
        public Guid? WarehouseId { get; set; }
        public Guid? ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid? UnitId { get; set; }
        public decimal Price { get; set; }
    }
}