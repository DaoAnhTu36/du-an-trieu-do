using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities
{
    [Table("FileManager", Schema = "SHOP")]
    public class FileManagerEntity : BaseEntity
    {
        public string Path { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}