using System.ComponentModel.DataAnnotations;
using Common.Model.Entitties;

namespace shop_food_api.Models
{
    public class CategoryModels
    {
    }

    public class CategoryModelRes
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? ParentId { get; set; }
    }

    public class CategoryModelReq
    {
        [Required]
        public string? Name { get; set; }

        public Guid? ParentId { get; set; }
    }

    public class ListCategoryModelReq : BasePageEntity
    {

    }
}