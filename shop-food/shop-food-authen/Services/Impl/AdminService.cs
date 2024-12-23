using Microsoft.EntityFrameworkCore;
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

        public async Task<ApiResponse<AdminSignInDTOResponse>> SignInAdmin(AdminSignInDTORequest instance)
        {
            var reval = new ApiResponse<AdminSignInDTOResponse>
            {
                IsNormal = true,
                MetaData = null,
                Data = null
            };
            try
            {
                var record = await _dbContext.AdminEntities.FirstOrDefaultAsync(x => x.Email == instance.Email);
                if (record == null)
                {
                    reval.MetaData = new MetaData
                    {
                        Message = "NotFound",
                        StatusCode = "204"
                    };
                }
                else
                {
                    reval.Data = new AdminSignInDTOResponse
                    {
                        Email = record.Email,
                        Name = record.Name,
                    };
                }
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

        public async Task<ApiResponse> SignUpAdmin(AdminSignUpDTORequest instance)
        {
            var reval = new ApiResponse
            {
                IsNormal = true,
                MetaData = null
            };
            try
            {
                var checkExist = await _dbContext.AdminEntities.FirstOrDefaultAsync(x => x.Email == instance.Email);
                if (checkExist != null)
                {
                    reval.IsNormal = false;
                    reval.MetaData = new MetaData
                    {
                        Message = "Account existed",
                        StatusCode = "203"
                    };

                    return reval;
                }
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