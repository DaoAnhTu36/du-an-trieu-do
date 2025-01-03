using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Model.Configs;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("Transaction", Schema = ConfigSchemaTableDatabase.WH)]
    public class TransactionWhEntity : BaseEntity
    {
        public string? TransactionCode { get; set; }
        public string? TransactionType { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}