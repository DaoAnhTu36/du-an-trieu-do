using Core.EF;
using shop_food_api.DatabaseContext.Entities;

namespace shop_food_api.Repositories
{
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
    }
}