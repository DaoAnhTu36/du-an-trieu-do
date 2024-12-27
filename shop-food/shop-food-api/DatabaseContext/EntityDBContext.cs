using Common.Model.Config;
using Infrastructure.ApiCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_food_api.DatabaseContext.Entities;
using shop_food_api.DatabaseContext.Entities.Warehouse;

namespace shop_food_api.DatabaseContext
{
    public class EntityDBContext : DbContext
    {
        private readonly IOptions<AppConfig> _appSetting;

        public EntityDBContext(DbContextOptions<EntityDBContext> options, IOptions<AppConfig> appSetting) : base(options)
        {
            _appSetting = appSetting;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ServiceExtensions.OverWriteConnectString(_appSetting);
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<FileManagerEntity> FileManagerEntities { get; set; }
        public DbSet<CategoryEntity> CategoryEntities { get; set; }

        #region warehouse area

        public DbSet<InventoryWarehouseEntity> InventoryWarehouseEntities { get; set; }
        public DbSet<ProductWarehouseEntity> ProductWarehouseEntities { get; set; }
        public DbSet<SupplierWarehouseEntity> SupplierWarehouseEntities { get; set; }
        public DbSet<TransactionWarehouseEntity> TransactionWarehouseEntities { get; set; }
        public DbSet<UnitWarehouseEntity> UnitWarehouseEntities { get; set; }
        public DbSet<WarehouseWarehouseEntity> WarehouseWarehouseEntities { get; set; }

        #endregion warehouse area
    }
}