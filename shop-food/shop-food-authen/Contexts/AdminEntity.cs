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

    public class AdminSignUpDTORequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }

    public class AdminSignInDTORequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class AdminSignInDTOResponse
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
    }
}