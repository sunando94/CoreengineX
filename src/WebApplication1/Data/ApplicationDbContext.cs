using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreenginex.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace coreenginex
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Business> businesses { get; set; }
        public DbSet<Reviews> reviews { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Attributes> attributes { get; set; }
        public DbSet<Store> shop { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Address> address { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StoreApplicationUser>().HasKey(x => new { x.Id, x.storeID });
            builder.Entity<StoreApplicationUser>().HasOne(pc => pc.User).WithMany(p => p.watch).HasForeignKey(pc => pc.Id);
            builder.Entity<StoreApplicationUser>().HasOne(pc => pc.store).WithMany(p => p.followers).HasForeignKey(pc => pc.storeID);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //one-to-many 
            //builder.Entity<Business>().HasOne<ApplicationUser>(s => s.User).WithMany(r => r.bussiness).HasForeignKey(g=>g.Id);
            //builder.Entity<UB_Ourteam>().HasKey(t => new { t.businessID, t.Id });
            //builder.Entity<UB_Ourteam>().HasOne(p => p.Business).WithMany(b => b.ourTeam).HasForeignKey(fk => fk.businessID);
            //builder.Entity<UB_Ourteam>().HasOne(p => p.user).WithMany(b => b.ourteam).HasForeignKey(fk => fk.Id);
            //builder.Entity<UB_follow>().HasOne(p => p.Business).WithMany(b => b.followers).HasForeignKey(fk => fk.businessID);
            //builder.Entity<UB_follow>().HasOne(p => p.user).WithMany(b => b.following).HasForeignKey(fk => fk.Id);
            //.HasRequired<Standard>(s => s.Standard) // Student entity requires Standard 
            //.WithMany(s => s.Students);

        }
    }
    public static class RolesData
    {
        private static readonly string[] Roles = new string[] { "Administrator", "Support", "Buziness","User","Blogger" };

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    await dbContext.Database.MigrateAsync();

                    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    foreach (var role in Roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }
                }
            }
        }
    }
}
