using coreenginex.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreenginex.Middleware
{
    public class SwaggerAuth
    {
        private readonly RequestDelegate _next;

        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;

        public SwaggerAuth(RequestDelegate next, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _next = next;

            _signInManager = signInManager;
            _userManager = userManager;

        }

        public  Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.Equals("/swagger/ui/index.html", StringComparison.Ordinal))
                return _next(context);
            try
            {
                var username = context.Request.Form["username"];
                var password = context.Request.Form["password"];
                if (username == "SwaggerUser" && password == "adminPass")
                    return _next(context);
                else
                {
                    context.Request.Path = "/";
                    return _next(context);
                }
            }
            catch(Exception)
            {
                context.Request.Path = "/";
                
                return _next(context);
            }
           
        }
    }
}
