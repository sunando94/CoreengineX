using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using coreenginex.Models;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Identity;

namespace coreenginex.Middleware
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOption _options;
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;

        public TokenProviderMiddleware(RequestDelegate next,IOptions<TokenProviderOption> options, SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            _next = next;
            _options = options.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            ThrowIfInvalidOptions(_options);
        }

        public Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
                return _next(context);
            if(!context.Request.Method.Equals("POST") || !context.Request.HasFormContentType)
            {    context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad Request");
            }
           // return null;
           return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];

            var identity = await GetIdentity(username, password);
            if (identity == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var claims = new Claim[]
            {
                       new Claim(JwtRegisteredClaimNames.Sub, username),
                       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                         new Claim(JwtRegisteredClaimNames.Iat, ((Int64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString(), ClaimValueTypes.Integer64)
                         ,identity.FindFirst(ClaimTypes.Role)
            };

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds
            };

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            
            ApplicationUser user = await _userManager.FindByNameAsync(username);
           
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.Succeeded)
            {   
                return await Task.FromResult(new ClaimsIdentity(new System.Security.Principal.GenericIdentity(username, "Token"), new Claim[] { new Claim(ClaimTypes.Role,"User") }));
            }
            return await Task.FromResult<ClaimsIdentity>(null);
        }
        private static void ThrowIfInvalidOptions(TokenProviderOption options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(options.SigningCredentials));
            }

         
        }
    }
}
