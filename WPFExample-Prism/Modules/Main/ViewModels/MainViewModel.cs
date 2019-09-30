using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPfExample.Data;
using WPfExample.Models;

namespace WPfExample.Main.ViewModels
{
    public class MainViewModel: BindableBase
    {
        public MainViewModel()
        {

            ShowDialogCommand = new DelegateCommand<string>(s =>
            {
                MessageBox.Show(s);
            }, s => true);
        }


        public ObservableCollection<Group> Groups { get; set; }


        private string message;
        public string Message 
        { 
            get => message; 
            set=> SetProperty(ref message, value, nameof(Message)); 
        }
        public ICommand ShowDialogCommand { get; } 
    }
}
	