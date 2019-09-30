using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFExample_NetcoreDI
{
    public static class IoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            Container = services.BuildServiceProvider();
        }

        public static void RegisterServices(this IServiceCollection services, Action<IServiceCollection> registration)
        {
            registration(services);
            Container = services.BuildServiceProvider();
        }

        public static IServiceCollection RegisterServices(Action<IServiceCollection> registration)
        {
            IServiceCollection services = new ServiceCollection();

            registration(services);

            return services;
        }

        public static IServiceProvider BuildContainer(this IServiceCollection services)
        {
            return Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }
    }
}
