using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPfExample.Data;
using WPfExample.ViewModels;
using WPfExample.Views;
using WPfExample.Regions;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using System.Windows.Navigation;
using Prism.Unity;
using Prism.Ioc;
using Prism.Regions;
using Prism.Modularity;
using System.Windows.Controls;
using WPfExample.Modules.Main;
using CommonServiceLocator;

namespace WPfExample
{

    public partial class App : PrismApplication
    {
        public IConfigurationRoot Configuration { get; }

        public App() : base()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IContext<InMemoryOptions>, InMemoryContext>();

            containerRegistry.Register<ShellWindow>();

            // containerRegistry.Register<MainViewModel>();
            // containerRegistry.RegisterForNavigation<MainPage>();

            // containerRegistry.Register<GroupListViewModel>();
            // containerRegistry.RegisterForNavigation<GroupListPage>();

            containerRegistry.RegisterInstance<IConfiguration>(Configuration);
            containerRegistry.RegisterInstance(Container);
            // ServiceLocator.SetLocatorProvider()
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog catalog)
        {
            catalog.AddModule<MainModule>();
            base.ConfigureModuleCatalog(catalog);
        }

    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    //public partial class App : Application
    //{
    //    public IConfigurationRoot Configuration { get; }

    //    public App()
    //    {
    //        Configuration = new ConfigurationBuilder()
    //            .AddJsonFile("appSettings.json")
    //            .Build();
    //        // here we add our appSettings.json as a configuration source
    //        // and we assign it to our Configuration property which we will
    //        // add to the DI.
    //    }

    //    protected override void OnStartup(StartupEventArgs e)
    //    {
    //        IoC.RegisterServices(s =>
    //        {
    //            s.AddSingleton(Configuration);

    //            s.AddScoped<IContext<InMemoryOptions>, InMemoryContext>();

    //            s.AddMemoryCache();

    //            s.AddScoped<Container>();

    //            s.AddScoped<MainPage>();
    //            s.AddScoped<MainViewModel>();

    //            s.AddScoped<GroupListPage>();
    //            s.AddScoped<GroupListViewModel>();
    //        });

    //        // this is just a shorthand to have a more readable code
    //        // you can replace this with 

    //        /* 
    //         * var services = new ServiceCollection();
    //         * services.AddScoped<MainWindow>();
    //         * services.AddScoped<MainWindowViewModel>();
    //         * var provider = services.BuildServiceProvider();
    //         * -----Or-----
    //         * IoC.RegisterServices(services);            
    //         */
    //        var mainWindow = IoC.Container.GetRequiredService<Container>();

    //        mainWindow.Show();
    //    }
    //}
}
