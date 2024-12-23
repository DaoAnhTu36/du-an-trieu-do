using System.ComponentModel.DataAnnotations;

namespace shop_food_authen.Contexts
{
    public class AdminEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
    }
}