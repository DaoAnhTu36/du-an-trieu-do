using System.ComponentModel.DataAnnotations;
using Common.Model.Entitties;

namespace shop_food_api.Models
{
    public class UploadFileResponseDTO
    {
        public List<FileUploadDTO>? FileIds { get; set; }
    }

    public class FileUploadDTO
    {
        public Guid? FileId { get; set; }
        public string? FileName { get; set; }
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