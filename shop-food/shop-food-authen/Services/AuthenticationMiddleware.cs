namespace shop_food_authen.Services
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Retrieve the "Authorization" header from the request
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                // Here, validate the token (e.g., check its signature, expiration, etc.)
                if (ValidateToken(token))
                {
                    // Token is valid, continue processing the request
                    await _next(context);
                    return;
                }
            }

            // Token is missing or invalid, return 401 Unauthorized
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
        }

        // Token validation logic (for example, you can check if it's in a database, check JWT validity, etc.)
        private bool ValidateToken(string token)
        {
            // Dummy check for example purposes
            return token == "valid-token"; // You should replace this with real validation
        }
    }
}