using Microsoft.EntityFrameworkCore;
using shop_food_api.DatabaseContext.Entities;

namespace shop_food_api.Repositories.Impl
{
    public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}