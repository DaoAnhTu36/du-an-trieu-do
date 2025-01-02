using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Configs;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("Supplier", Schema = ConfigSchemaTableDatabase.WH)]
    public class SupplierWhEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public ICollection<TransactionDetailWhEntity>? TransactionDetails { get; set; }
    }
}