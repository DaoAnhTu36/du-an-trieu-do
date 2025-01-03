﻿using System.ComponentModel.DataAnnotations.Schema;
using Common.Model.Configs;
using Common.Model.Entitties;

namespace shop_food_api.DatabaseContext.Entities.Warehouse
{
    [Table("Warehouse", Schema = ConfigSchemaTableDatabase.WH)]
    public class WarehouseWhEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}