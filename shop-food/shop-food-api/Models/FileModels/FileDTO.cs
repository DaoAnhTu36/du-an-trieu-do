using System.ComponentModel.DataAnnotations;
using Common.Model.Entitties;

namespace shop_food_api.Models.FileModels
{
    public class UploadFileRequestDTO
    {
    }

    public class UploadFileResponseDTO
    {
        [Required]
        public IFormFile Path { get; set; }
    }

    public class ItemFileManagerRequestDTO : BasePageEntity
    {
    }

    public class ItemFileManagerResponseDTO
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
    }
}