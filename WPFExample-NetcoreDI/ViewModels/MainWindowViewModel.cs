using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WPFExample_NetcoreDI;
using WPFExample_NetcoreDI.Views;

namespace WPFExample_NetcoreDI.ViewModels
{
    public class MainWindowViewModel: ObservableObject
    {
        NavigationService navigationService;
        Dictionary<string, Type> Pages;
        public MainWindowViewModel()
        {
            this.NavigationFrame = new Frame();
            this.navigationService = NavigationFrame.NavigationService;
            this.NavigateCommand = new RelayCommand<string>(Navigate);
            this.Pages = new Dictionary<string, Type>()
            {
                { "MainPage", typeof(MainPage) },
                { "MemberList", typeof(MemberListView) }
            };
        }

        private void Navigate(string page)
        {
            Type pageType;
            if (this.Pages.TryGetValue(page, out pageType))
            {
                var pageInstance = IoC.Container.GetRequiredService(pageType);
                this.navigationService.Navigate(pageInstance);
            }
        }

        public ICommand NavigateCommand { get; } 

        public Frame NavigationFrame { get; }

    }
}
