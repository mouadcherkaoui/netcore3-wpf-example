
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPfExample.Data;
using WPfExample.Models;

namespace WPfExample.ViewModels
{
    public class MainWindowViewModel: ObservableObject
    {
        IContext<InMemoryOptions> context;
        public MainWindowViewModel()
        {
            context = IoC.Container.GetRequiredService<IContext<InMemoryOptions>>();

            Groups = context
                .Set<Group>()
                .ToList()
                .PipeTo(g => new ObservableCollection<Group>(g));            

            ShowDialogCommand = new RelayCommand<string>(execute: s =>
            {
                MessageBox.Show(s);
            }, canExecute: s => true);
        }


        public ObservableCollection<Group> Groups { get; set; }


        private string message;
        public string Message 
        { 
            get => message; 
            set=> Set(nameof(Message), ref message, value); 
        }
        public ICommand ShowDialogCommand { get; } 
    }
}
	