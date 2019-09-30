using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPfExample
{
    public static class IoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            Container = services.BuildServiceProvider();
        }

        public static void RegisterServices(IServiceCollection services, Action<IServiceCollection> registration)
        {
            registration(services);
            Container = services.BuildServiceProvider();
        }

        public static IServiceCollection RegisterServices(Action<IServiceCollection> registration)
        {
            IServiceCollection services = new ServiceCollection();

            registration(services);

            Container = services.BuildServiceProvider();
            
            return services;
        }

        public static IServiceProvider Container { get; private set; }
    }
}
