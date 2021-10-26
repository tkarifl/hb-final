﻿using Hb_Project.Domain.Repositories;
using Hb_Project.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Infrastructure.Extensions
{
    public static class InfrastructureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<hb_ecommerceContext>(options =>
            options.UseNpgsql("Host=127.0.0.1;Database=hb_ecommerce;Username=postgres;Password=12345"));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IListRepository, ListRepository>();
            services.AddScoped<IListItemRepository, ListItemRepository>();
            return services;
        }
    }
}
