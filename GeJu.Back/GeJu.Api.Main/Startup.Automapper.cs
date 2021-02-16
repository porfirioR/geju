﻿using GeJu.Api.Main.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace GeJu.Api.Main
{
    public partial class Startup
    {
        public void ConfigureMappings(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(UserProfile),
                typeof(Services.Admin.Mapper.UserProfile)
            );
        }
    }
}
