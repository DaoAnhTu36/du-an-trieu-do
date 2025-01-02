using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Configs;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("TransactionDetail", Schema = ConfigSchemaTableDatabase.WH)]
    public class TransactionDetailWhEntity : BaseEntity
    {
        [Required]
        public Guid? TransactionId { get; set; }

        public Guid? ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid? UnitId { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        public DateTime? DateOfExpired { get; set; }
        public TransactionWhEntity? Transactions { get; set; }
        public ICollection<ProductEntity>? Products { get; set; }
    }
}