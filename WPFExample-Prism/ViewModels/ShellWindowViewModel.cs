using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Unity;
using WPfExample.Views;

namespace WPfExample.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public ShellWindowViewModel(): this(CommonServiceLocator.ServiceLocator.Current.GetInstance<IRegionManager>())
        {

        }
        [InjectionConstructor]
        public ShellWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }
    }
}
