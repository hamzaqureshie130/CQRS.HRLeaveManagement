using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection  ConfigureApplicationServices(this IServiceCollection services)
        {
            // Add application services here (e.g., AutoMapper, MediatR, Validators, etc.)
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }

    }
}
