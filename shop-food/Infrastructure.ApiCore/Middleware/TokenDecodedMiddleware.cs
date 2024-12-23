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
                        if (token.Payload.TryGetValue("sub", out object sub) &&
                            !string.IsNullOrEmpty(sub as string))
                        {
                            context.Request.Headers.Add("sub", (string)sub);
                            _logger.LogInformation($"TOKEN DECODED -> sub {(string)sub}");
                        }

                        if (token.Payload.TryGetValue("email", out object email) &&
                            !string.IsNullOrEmpty(email as string))
                        {
                            context.Request.Headers.Add("email", (string)email);
                            _logger.LogInformation($"TOKEN DECODED -> email {(string)email}");
                        }

                        if (token.Payload.TryGetValue("name", out object name) &&
                            !string.IsNullOrEmpty(name as string))
                        {
                            context.Request.Headers.Add("name", (string)name);
                            _logger.LogInformation(
                                $"TOKEN DECODED -> name {(string)name}");
                        }

                        if (token.Payload.TryGetValue("exp", out object exp) &&
                            !string.IsNullOrEmpty(exp as string))
                        {
                            context.Request.Headers.Add("exp", (string)exp);
                            _logger.LogInformation(
                                $"TOKEN DECODED -> exp {(string)exp}");
                        }

                        if (token.Payload.TryGetValue("iss", out object iss) &&
                            !string.IsNullOrEmpty(iss as string))
                        {
                            context.Request.Headers.Add("iss", (string)iss);
                            _logger.LogInformation(
                                $"TOKEN DECODED -> iss {(string)iss}");
                        }

                        if (token.Payload.TryGetValue("aud", out object aud) &&
                            !string.IsNullOrEmpty(aud as string))
                        {
                            context.Request.Headers.Add("aud", (string)aud);
                            _logger.LogInformation(
                                $"TOKEN DECODED -> aud {(string)aud}");
                        }

                        if (token.Payload.TryGetValue("jti", out object jti) &&
                            !string.IsNullOrEmpty(jti as string))
                        {
                            context.Request.Headers.Add("jti", (string)jti);
                            _logger.LogInformation(
                                $"TOKEN DECODED -> jti {(string)jti}");
                        }

                        context.Response.StatusCode = StatusCodes.Status417ExpectationFailed;
                        await context.Response.WriteAsync("Unauthorized");
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                await _next(context);
            }
        }
    }
}