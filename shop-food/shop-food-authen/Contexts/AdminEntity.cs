using System.ComponentModel.DataAnnotations;
using shop_food_authen.DTO;

namespace shop_food_authen.Contexts
{
    public class AdminEntity : BaseEntity
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        [Required]
        public string? PasswordSalt { get; set; }
    }

    public class AdminSignUpDTORequest
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }

    public class AdminSignInDTORequest
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }

    public class AdminSignInDTOResponse : TokenDTO
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}