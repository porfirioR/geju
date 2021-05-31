using Access.Contract.Admin.Interfaces;
using Access.Contract.Interfaces;
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
            services.AddTransient<IAuthDataAccess, AuthDataAccess>();
            services.AddTransient<IColorDataAccess, ColorDataAccess>();
            services.AddTransient<IPermissionDataAccess, PermissionDataAccess>();
        }
    }
}
