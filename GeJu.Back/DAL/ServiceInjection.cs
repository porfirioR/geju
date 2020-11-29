using DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public class ServiceInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBrandDAL, BrandDAL>();
        }
    }
}
