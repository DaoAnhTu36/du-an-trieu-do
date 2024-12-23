using Infrastructure.ApiCore;
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
                    var tokenInfo = JWTExtensions.GenerateToken(record.Id.ToString(), record.Email, record.Name, out DateTime datetimeExpired);
                    reval.Data = new AdminSignInDTOResponse
                    {
                        Email = record.Email,
                        Name = record.Name,
                        AccessToken = tokenInfo,
                        ExpiredDate = datetimeExpired
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
                if (instance == null)
                {
                    return new ApiResponse
                    {
                        IsNormal = false,
                        MetaData = new MetaData
                        {
                            Message = "BadRequest",
                            StatusCode = "400"
                        }
                    };
                }
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
                PasswordExtensions.CreatePassword(instance.Password ?? "default", out var passwordHash, out var passwordSalt);
                var entity = new AdminEntity
                {
                    Name = instance.Name,
                    Email = instance.Email,
                    PasswordHash = passwordHash.ToString(),
                    PasswordSalt = passwordSalt.ToString(),
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