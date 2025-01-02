using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Configs;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("Transaction", Schema = ConfigSchemaTableDatabase.WH)]
    public class TransactionWhEntity : BaseEntity
    {
        public string? TransactionType { get; set; }
        public Guid? WarehouseIdTo { get; set; }
        public Guid? WarehouseIdFrom { get; set; }
        public ICollection<TransactionDetailWhEntity>? TransactionDetails { get; set; }
    }
}