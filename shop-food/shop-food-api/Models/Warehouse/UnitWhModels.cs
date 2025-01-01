using System.ComponentModel.DataAnnotations;
using Common.Model.Entitties;
using Common.User;

namespace shop_food_api.Models.Warehouse
{
    #region model create new record

    public class UnitWhCreateModelReq
    {
        public string Name { get; set; }
    }

    public class UnitWhCreateModelRes
    {
    }

    #endregion model create new record

    #region model update record

    public class UnitWhUpdateModelRes
    {
    }

    public class UnitWhUpdateModelReq
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    #endregion model update record

    #region model delete record

    public class UnitWhDeleteModelReq
    {
        public Guid Id { get; set; }
    }

    public class UnitWhDeleteModelRes
    {
    }

    #endregion model delete record

    #region model get list record

    public class UnitWhListModelRes
    {
        public IEnumerable<UnitWhModel> List { get; set; }
    }

    public class UnitWhListModelReq : BasePageEntity
    {
    }

    #endregion model get list record

    public class UnitWhModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}