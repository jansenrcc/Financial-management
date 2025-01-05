using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Core.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Financial.Api.Configuration
{
    public static class DbContextConfig
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            return builder;
        }
    }
}