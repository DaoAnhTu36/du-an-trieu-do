using System.IdentityModel.Tokens.Jwt;
using Common.Logger;
using Common.StatusCode;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ApiCore.Middleware
{
    public class TokenDecodedMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TokenDecodedMiddleware> _logger;

        public TokenDecodedMiddleware(RequestDelegate next, ILogger<TokenDecodedMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var className = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            var methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
            var messageError = string.Empty;
            try
            {
                if (context.Request.Path.Value?.Contains("admin/sign-in") == true
                    || context.Request.Path.Value?.Contains("admin/sign-up") == true)
                {
                    await _next(context);
                    return;
                }
                var tokenString = context.Request.Headers["authorization"].ToString();
                if (!string.IsNullOrEmpty(tokenString))
                {
                    var jwtEncodedString = tokenString;
                    if (tokenString.Contains("Bearer") || tokenString.Contains("bearer"))
                    {
                        jwtEncodedString = tokenString.Substring(7);
                    }

                    var token = new JwtSecurityToken(jwtEncodedString);
                    if (token.Payload != null)
                    {
                        if (token.ValidTo > DateTime.Now)
                        {
                            LoggerService.LogInfo(StatusLogger.FormatLogger(className, methodName, "TokenDecodedMiddleware", true));
                            await _next(context);
                            LoggerService.LogInfo(StatusLogger.FormatLogger(className, methodName, "TokenDecodedMiddleware", false));
                            return;
                        }
                    }
                    else
                    {
                        messageError = "Token is invalid";
                    }
                }
                else
                {
                    messageError = "Token is empty";
                }
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
            }
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync(messageError);
        }
    }
}