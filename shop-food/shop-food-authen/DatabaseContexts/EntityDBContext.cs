using Microsoft.EntityFrameworkCore;

namespace shop_food_authen.Contexts
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

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<AdminEntity> AdminEntities { get; set; }
    }
}