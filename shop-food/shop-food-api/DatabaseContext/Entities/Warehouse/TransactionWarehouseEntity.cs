using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Configs;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("Transaction", Schema = ConfigSchemaTableDatabase.WH)]
    public class TransactionWarehouseEntity : BaseEntity
    {
        /// <summary>
        /// type transaction: import or export (use enum class: ConfigTypeTransaction)
        /// </summary>
        public string? TransactionType { get; set; }
        public Guid? WarehouseId { get; set; }
        public Guid? ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid? UnitId { get; set; }
    }
}