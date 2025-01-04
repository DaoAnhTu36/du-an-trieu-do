using Common.User;
using System.ComponentModel.DataAnnotations;

namespace shop_food_api.Models.Warehouse
{
    public class TransactionDetailModels
    {
        public string? ProductBarCode { get; set; }
        public string? ProductName { get; set; }
        public string? SupplierName { get; set; }
        public string? UnitName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        public DateTime? DateOfExpired { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
