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
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;

namespace WPfExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfigurationRoot Configuration { get; set; }
        
        public App()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            // here we add our appSettings.json as a configuration source
            // and we assign it to our Configuration property which we will
            // add to the DI.
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            IoC.RegisterServices(s =>
            {
                s.AddSingleton(Configuration);

                s.AddScoped<IContext<InMemoryOptions>, InMemoryContext>();

                s.AddMemoryCache();
                
                s.AddScoped<MainWindow>();
                s.AddScoped<MainWindowViewModel>();
            })
            .BuildContainer(); 

            // this is just a shorthand to have a more readable code
            // you can replace this with 

            /* 
             * var services = new ServiceCollection();
             * services.AddScoped<MainWindow>();
             * services.AddScoped<MainWindowViewModel>();
             * var provider = services.BuildServiceProvider();
             * -----Or-----
             * IoC.RegisterServices(services);            
             */
            var mainWindow = IoC.Container.GetRequiredService<MainWindow>();
            
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
