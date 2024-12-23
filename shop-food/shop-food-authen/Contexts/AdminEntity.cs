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

    public class AdminDTORequest
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }
    }
}