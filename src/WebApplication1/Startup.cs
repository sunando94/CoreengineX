using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using coreenginex.Models;
using coreenginex.Repository;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using coreenginex.Services;
using coreenginex.Middleware;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace coreenginex
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
       
                
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("AllowedSecretKey"));
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            services.AddOptions();
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            Debug.WriteLine(Configuration.GetConnectionString("DefaultConnection"));
            //Repo linking
            services.AddScoped(typeof(ICategoryRepository),typeof(CategoryRepository));
            services.AddScoped(typeof(ISubCategoryRepository), typeof(SubCategoryRepository));



            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddUserStore<ApplicationUserStore>()
               .AddDefaultTokenProviders();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddAuthorization();
            services.AddMvc();
            services.AddSwaggerGen(
                c => {
                    c.OperationFilter<FileOperationFilter>();
                    c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                }
                );
            
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
          //  app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            var signingKey = _signingKey;
            var options = new TokenProviderOption
            {
                Audience = "http://localhost:52193/",
                Issuer = "coreenginex",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),


            };
             RolesData.SeedRoles(app.ApplicationServices).Wait();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "images", "profilepic")),
                RequestPath = new PathString("/images")
            }
               );
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "images", "logo")),
                RequestPath = new PathString("/logo")
            }
               );
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "images", "gallery")),
                RequestPath = new PathString("/gallery")
            }
               );
            app.UseJwtBearerAuthentication(new JwtBearerOptions()
            {
                AuthenticationScheme = JwtBearerDefaults.AuthenticationScheme,
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = signingKey,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = "http://localhost:52193/",
                    ValidIssuer = "coreenginex"
                }
            });


            app.UseCors("CorsPolicy");
            

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715
            
            app.UseIdentity();
          

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
           // app.UseMiddleware<SwaggerAuth>();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "Home", template: "{controller}/{action}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "api/{controller}/{action}/{id?}",
                    defaults: new { controller = "Category", action = "Get" });


            });
            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();
        }

    }
}
