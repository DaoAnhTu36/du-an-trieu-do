using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Configs;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("Unit", Schema = ConfigSchemaTableDatabase.WH)]
    public class UnitWarehouseEntity : BaseEntity
    {
        public string? Name { get; set; }
    }
}