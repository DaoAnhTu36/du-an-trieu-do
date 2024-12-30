using Common.Model.Entitties;

namespace shop_food_api.Models.Warehouse
{
    #region model create new record

    public class ProductWhCreateModelReq
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class ProductWhCreateModelRes
    {
    }

    #endregion model create new record

    #region model update record

    public class ProductWhUpdateModelRes
    {
    }

    public class ProductWhUpdateModelReq
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    #endregion model update record

    #region model delete record

    public class ProductWhDeleteModelReq
    {
        public Guid Id { get; set; }
    }

    public class ProductWhDeleteModelRes
    {
    }

    #endregion model delete record

    #region model get list record

    public class ProductWhListModelRes
    {
        public IEnumerable<ProductWhModel> List { get; set; }
    }

    public class ProductWhListModelReq : BasePageEntity
    {
    }

    #endregion model get list record

    public class ProductWhModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}