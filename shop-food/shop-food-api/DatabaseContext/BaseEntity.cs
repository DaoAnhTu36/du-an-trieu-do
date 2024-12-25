﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_food_api.DatabaseContext
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [Required]
        public string CreatedBy { get; set; } = "admin";

        [Required]
        public string UpdatedBy { get; set; } = "admin";
    }

    public class BasePageEntity
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}