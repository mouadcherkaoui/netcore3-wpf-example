using GalaSoft.MvvmLight;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WPFExample_NetcoreDI;
using WPFExample_NetcoreDI.Data;
using WPFExample_NetcoreDI.Models;

namespace WPFExample_NetcoreDI.ViewModels
{
    public class MemberListViewModel : ObservableObject
    {
        IContext<InMemoryOptions> _context;
        public MemberListViewModel(): this(IoC.Container.GetRequiredService<IContext<InMemoryOptions>>())
        {
        }

        public MemberListViewModel(IContext<InMemoryOptions> context)
        {
            this._context = context;

            Members = context
                .Set<Member>()
                .ToList()
                .PipeTo(m => new ObservableCollection<Member>(m));

        }

        public ObservableCollection<Member> Members { get; set; }

    }
}
