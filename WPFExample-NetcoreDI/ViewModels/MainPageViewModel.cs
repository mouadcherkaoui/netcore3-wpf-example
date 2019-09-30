
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFExample_NetcoreDI.Data;
using WPFExample_NetcoreDI.Models;

namespace WPFExample_NetcoreDI.ViewModels
{
    public class MainPageViewModel: ObservableObject
    {
        public MainPageViewModel()
        {
            ShowDialogCommand = new RelayCommand<string>(execute: s =>
            {
                MessageBox.Show(s);
            }, canExecute: s => true);
        }

        private string message;
        public string Message 
        { 
            get => message; 
            set=> Set(nameof(Message), ref message, value); 
        }
        public ICommand ShowDialogCommand { get; } 
    }
}
	