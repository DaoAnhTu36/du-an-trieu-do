using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
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
                        var isValidToken = JWTExtensions.ValidateToken(tokenString.Replace("Bearer ",""));
                        if (isValidToken)
                        {
                            await _next(context);
                            return;
                        }
                    }
                }
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
            }
            catch (Exception)
            {
            }
        }
    }
}