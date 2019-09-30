using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFExample_NetcoreDI.Models;

namespace WPFExample_NetcoreDI.Data
{
    public class InMemoryContext : DbContext, IContext<InMemoryOptions>
    {
        public InMemoryContext()
        {
            Options = new InMemoryOptions();
            InitializeInMemoryData();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var applyConfig = modelBuilder.GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name.StartsWith("ApplyConfiguration"));

            foreach (var typeConfig in Options.TypesConfig)
            {
                var type = typeConfig.GetInterfaces().First().GetGenericArguments().First();
                applyConfig.MakeGenericMethod(type).Invoke(modelBuilder, new[] { Activator.CreateInstance(typeConfig) });
            };

            base.OnModelCreating(modelBuilder);
        }

        public void InitializeInMemoryData()
        {
            var groups = Options.InMemoryGroups;
            var members = Options.InMemoryMembers;

            Set<Group>().AddRange(groups);
            Set<Member>().AddRange(members);
            base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("myInMemoryTests");
            base.OnConfiguring(optionsBuilder);
        }

        public async Task<int> CommitChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public InMemoryOptions Options { get; }

    }
}
