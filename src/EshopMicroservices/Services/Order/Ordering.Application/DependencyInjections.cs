using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ordering.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection ApplicationDependencies(this IServiceCollection services)
        {
            //services.AddMediatR(config =>
            //{
            //    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //});
            return services;
        }
    }
}
