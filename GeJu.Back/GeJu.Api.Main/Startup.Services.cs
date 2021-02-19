using GeJu.Services.Admin;
using Manager.Admin;
using Microsoft.Extensions.DependencyInjection;

namespace GeJu.Api.Main
{
    public partial class Startup
    {
        public void InjectServices(IServiceCollection services)
        {
            ServiceInjection.ConfigureServices(services);
            ServiceInjection.ConfigureServices(services);
        }
    }
}
