using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_food_api.DatabaseContext.Entities
{
    [Table("FileManager", Schema = "SHOP")]
    public class FileManagerEntity : BaseEntity
    {
        public string Path { get; set; } = string.Empty;
    }
}