using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPfExample.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }

    public class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> entity)
        {
            entity.HasKey(g => g.Id);
            entity.Property(g => g.Name).IsRequired();
            entity.Property(g => g.Description).IsRequired();
            entity.HasMany(g => g.Members)
                .WithOne(m => m.Group)
                .HasForeignKey(m => m.GroupId);
        }
    }
}
