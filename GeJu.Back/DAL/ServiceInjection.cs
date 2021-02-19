using Contract.Brands;
using Contract.Users;
using Manager.Admin.Brands;
using Manager.Admin.Sizes;
using Manager.Admin.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Manager.Admin
{
    public class ServiceInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBrandManager, BrandManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<ISizeManager, SizeManager>();
        }
    }
}
