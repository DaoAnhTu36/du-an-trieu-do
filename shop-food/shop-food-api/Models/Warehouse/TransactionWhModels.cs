namespace shop_food_api.Models.Warehouse
{
    #region model create new record

    public class TransactionWhCreateModelReq
    {
        public string? TransactionCode { get; set; }

        /// <summary>
        /// 0 import
        /// 1 export
        /// </summary>
        public string? TransactionType { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<SubTransactionWhCreateModelReq>? Details { get; set; }
    }

    public class SubTransactionWhCreateModelReq
    {
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        public DateTime? DateOfExpired { get; set; }
    }

    public class TransactionWhCreateModelRes
    {
    }

    #endregion model create new record

    #region model update record

    public class TransactionWhUpdateModelRes
    {
    }

    public class TransactionWhUpdateModelReq
    {
    }

    #endregion model update record

    #region model delete record

    public class TransactionWhDeleteModelReq
    {
    }

    public class TransactionWhDeleteModelRes
    {
    }

    #endregion model delete record

    #region model get list record

    public class TransactionWhListModelRes
    {
    }

    public class TransactionWhListModelReq
    {
    }

    #endregion model get list record

    #region model get detail record

    public class TransactionWhDetailModelRes
    {
    }

    public class TransactionWhDetailModelReq
    {
        public Guid Id { get; set; }
    }

    #endregion model get detail record
}