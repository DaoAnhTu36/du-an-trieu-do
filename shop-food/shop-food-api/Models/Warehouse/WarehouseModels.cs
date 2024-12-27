using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model.Entitties;

namespace shop_food_api.Models.Warehouse
{
    internal class WarehouseModels
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
}