﻿using GeJu.Services.Admin.Implementations;
using GeJu.Services.Admin.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GeJu.Services.Admin
{
    public class ServiceInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUsersServices, UsersServices>();
        }
    }
}
