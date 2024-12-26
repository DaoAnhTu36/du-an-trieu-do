using System.ComponentModel.DataAnnotations;
using Common.Model.Entitties;

namespace shop_food_api.Models
{
    public class CategoryModels
    {
    }

    public class ApiListCategoryModelRes
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? ParentId { get; set; }
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
    }

    public class ApiCreateCategoryModelReq
    {
        [Required]
        public string? Name { get; set; }

        public Guid? ParentId { get; set; }
    }

    public class ApiListCategoryModelReq : BasePageEntity
    {

    }
}