using System.ComponentModel.DataAnnotations;
using shop_food_authen.DTO;

namespace shop_food_authen.Contexts
{
    public class AdminEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string PasswordSalt { get; set; } = string.Empty;
    }

    public class AdminSignUpDTORequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class AdminSignInDTORequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class AdminSignInDTOResponse : TokenDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
    }

    public class AdminInforResponseDTO : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
    public class AdminInforRequestDTO : BasePageEntity
    {
    }
}