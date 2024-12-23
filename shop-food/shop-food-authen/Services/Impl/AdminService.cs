using shop_food_authen.Contexts;
using utility;

namespace shop_food_authen.Services.Impl
{
    public class AdminService : IAdminService
    {
        private readonly EntityDBContext _dbContext;

        public AdminService(EntityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponse> SignUpAdmin(AdminDTORequest instance)
        {
            var reval = new ApiResponse();
            try
            {
                var entity = new AdminEntity
                {
                    Name = instance.Name,
                    Email = instance.Email,
                };
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                reval.IsNormal = false;
                reval.MetaData = new MetaData
                {
                    Message = ex.Message,
                    StatusCode = "500"
                };
            }
            return reval;
        }
    }
}