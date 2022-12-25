using Core.Data.DataContext;
using Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BaseProject.Infrastructure
{
    public class IdentityRegister
    {
        public IdentityRegister(WebApplicationBuilder applicationBuilder)
        {
            ConfigurationManager configuration = applicationBuilder.Configuration;
            IServiceCollection services = applicationBuilder.Services;
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   sqlServerOptionsAction: sql =>
                   {
                       sql.EnableRetryOnFailure(
                           maxRetryCount: 10,
                           maxRetryDelay: TimeSpan.FromSeconds(2),
                       errorNumbersToAdd: null
                           );
                   }));
            services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddRoles<Role>();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.  
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireUppercase = true;

                // Lockout settings.  
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.  
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@!";
                options.User.RequireUniqueEmail = true;
            });
        }
    }
}
