using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop_food_api.DatabaseContext.Entities;

namespace shop_food_api.DatabaseContext
{
    public class EntityDBContext : DbContext
    {
        public EntityDBContext(DbContextOptions<EntityDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = string.Empty;
            connectionString = "Server=DAOANHTU\\SQLEXPRESS;Database=db_authen;User Id=sa;password=123456@b;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            connectionString = "Server=PEACHY\\SQLEXPRESS;Database=db_authen;User Id=sa;password=123456@b;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            connectionString = "Server=PEACHY\\SQLEXPRESS;Database=db_shop;User Id=sa;password=123456@b;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<FileManagerEntity> FileManagerEntities { get; set; }
    }
}
