using AutoMapper;
using Hb_Project.Application.IServices;
using Hb_Project.Application.Mapper;
using Hb_Project.Application.Services;
using Hb_Project.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Application.Extensions
{
     static class ApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddInfrastructureServices();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IListService, ListService>();
            services.AddScoped<IListItemService, ListItemService>();
            services.AddScoped<IItemService, ItemService>();
            return services;
        }
    }
}
