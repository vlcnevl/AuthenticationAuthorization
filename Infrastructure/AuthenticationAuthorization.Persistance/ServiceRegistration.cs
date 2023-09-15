using AuthenticationAuthorization.Application.Abstraction.Services;
using AuthenticationAuthorization.Domain.Entities.Identity;
using AuthenticationAuthorization.Persistance.Contexts;
using AuthenticationAuthorization.Persistance.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace AuthenticationAuthorization.Persistance
{
    public static class ServiceRegistration
    {
             
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<AuthenticationAuthorizationDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));


            services.AddIdentity<AppUser, AppRole>(options => 
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            
            }).AddEntityFrameworkStores<AuthenticationAuthorizationDbContext>();
            services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(1));



            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAuthService,AuthService>();

        }


        


    }
}
