using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Configs;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("TransactionDetail", Schema = ConfigSchemaTableDatabase.WH)]
    public class TransactionDetailWhEntity : BaseEntity
    {
        [ForeignKey("TransactionId")]
        public Guid? TransactionId { get; set; }

        [ForeignKey("ProductId")]
        public Guid? ProductId { get; set; }

        [ForeignKey("SupplierId")]
        public Guid? SupplierId { get; set; }

        [ForeignKey("UnitId")]
        public Guid? UnitId { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        public DateTime? DateOfExpired { get; set; }
        public TransactionWhEntity? Transactions { get; set; }
        public ProductWhEntity? Products { get; set; }
        public SupplierWhEntity? Suppliers { get; set; }
        public UnitWhEntity? Units { get; set; }
    }
}