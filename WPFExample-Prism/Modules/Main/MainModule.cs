using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using WPfExample.Main.Views;
using WPfExample.Main.ViewModels;

namespace WPfExample.Modules.Main
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MainView));
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(GroupListView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<MainViewModel>();
            containerRegistry.Register<GroupListViewModel>();

            //containerRegistry.RegisterForNavigation<MainView>();
            //containerRegistry.RegisterForNavigation<GroupListView>();
        }
    }
}
