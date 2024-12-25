using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}