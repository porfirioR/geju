using Admin.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Admin
{
    public class ServiceInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserDataAccess, UserDataAccess>();
            services.AddTransient<IBrandDataAccess, BrandDataAccess>();
            services.AddTransient<ISizeDataAccess, SizeDataAccess>();
            services.AddScoped<IAuthDataAccess, AuthDataAccess>();
        }
    }
}
