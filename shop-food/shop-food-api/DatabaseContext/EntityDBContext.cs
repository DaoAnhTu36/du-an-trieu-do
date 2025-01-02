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

        public DbSet<InventoryWhEntity> InventoryWhEntities { get; set; }
        public DbSet<ProductWhEntity> ProductWhEntities { get; set; }
        public DbSet<SupplierWhEntity> SupplierWhEntities { get; set; }
        public DbSet<TransactionWhEntity> TransactionWhEntities { get; set; }
        public DbSet<UnitWhEntity> UnitWhEntities { get; set; }
        public DbSet<WarehouseWhEntity> WarehouseWhEntities { get; set; }

        #endregion warehouse area

        public DbSet<NotificationEntity> NotificationEntities { get; set; }
        public DbSet<TransactionDetailWhEntity> TransactionDetailWhEntities { get; set; }
    }
}