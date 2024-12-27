using Common.Model.Config;
using Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_food_api.DatabaseContext.Entities.Warehouse;

namespace shop_food_api.Services.Warehouse.Impl
{
    public class ProductWarehouseService : Repository<ProductWarehouseEntity>, IProductWarehouseService
    {
        private readonly IOptions<AppConfig> _options;
        private readonly IUnitOfWork _unitOfWork;

        public ProductWarehouseService(IUnitOfWork unitOfWork
            , DbContext context
            , IOptions<AppConfig> options) : base(context)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }
    }
}