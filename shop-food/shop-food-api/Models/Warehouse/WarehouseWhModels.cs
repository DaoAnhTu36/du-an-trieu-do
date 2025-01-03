﻿using System.ComponentModel.DataAnnotations;
using Common.Model.Entitties;
using shop_food_api.DatabaseContext.Entities.Warehouse;

namespace shop_food_api.Models.Warehouse
{
    internal class WarehouseWhModels
    {
    }

    public class WarehouseCreateModelReq
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }
    }

    public class WarehouseCreateModelRes
    {
    }

    public class WarehouseUpdateModelReq
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class WarehouseUpdateModelRes
    {
    }

    public class WarehouseDeleteModelReq
    {
        [Required]
        public Guid Id { get; set; }
    }

    public class WarehouseDeleteModelRes
    {
    }

    public class WarehouseListModelReq : BasePageEntity
    {
    }

    public class WarehouseListModelRes
    {
        public IEnumerable<WarehouseInfoModel>? ListWarehouse { get; set; }
    }

    public class WarehouseInfoModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class WarehouseWhDetailModelRes : WarehouseWhEntity
    {
    }

    public class WarehouseWhDetailModelReq
    {
        public Guid Id { get; set; }
    }

    public class WarehouseWhDetailByIdModelRes : WarehouseInfoModel
    {
    }

    public class WarehouseWhDetailByIdModelReq
    {
        public Guid Id { get; set; }
    }
}