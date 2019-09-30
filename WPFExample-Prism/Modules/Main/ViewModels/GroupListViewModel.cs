using CommonServiceLocator;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WPfExample.Data;
using WPfExample.Models;

namespace WPfExample.Main.ViewModels
{
    class GroupListViewModel
    {
        private readonly IContext<InMemoryOptions> context;
        public GroupListViewModel(): this(ServiceLocator.Current.GetInstance<IContainerProvider>())
        {

        }
        public GroupListViewModel(IContainerProvider container)
        {
            context = container.Resolve<IContext<InMemoryOptions>>();
            // this.context = context; // IoC.Container.GetRequiredService<IContext<InMemoryOptions>>();

            Groups = context
                .Set<Group>()
                .ToList()
                .PipeTo(g => new ObservableCollection<Group>(g));

        }
        public ObservableCollection<Group> Groups { get; set; }
    }
}
