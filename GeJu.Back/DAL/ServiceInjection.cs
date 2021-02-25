﻿using Manager.Admin.Brands;
using Manager.Admin.Sizes;
using Manager.Admin.Users;
using Microsoft.Extensions.DependencyInjection;
using Resources.Contract.Brands;
using Resources.Contract.Sizes;
using Resources.Contract.Users;

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
