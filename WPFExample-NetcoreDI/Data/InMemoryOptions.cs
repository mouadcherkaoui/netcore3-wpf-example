using System;
using System.Collections.Generic;
using WPfExample.Models;

namespace WPfExample.Data
{
    public class InMemoryOptions
    {
        public InMemoryOptions()
        {
            Types = new Type[] { typeof(Member), typeof(Group) };
            TypesConfig = new Type[] { typeof(MemberConfig), typeof(GroupConfig) };

        }
        public Type[] Types { get; } 
        public Type[] TypesConfig { get; }

        public List<Member> InMemoryMembers
        {
            get => new List<Member>()
            {
                new Member
                {
                    Id = 4,
                    FirstName = "firstname1",
                    LastName = "lastname1",
                    EmailAddress = "mail@server.com"
                },
                new Member
                {
                    Id = 5,
                    FirstName = "firstname1",
                    LastName = "lastname1",
                    EmailAddress = "mail@server.com"
                },new Member
                {
                    Id = 6,
                    FirstName = "firstname1",
                    LastName = "lastname1",
                    EmailAddress = "mail@server.com"
                }
            };
        }

        public List<Group> InMemoryGroups
        {
            get => new List<Group>()
            {
                new Group
                {
                    Id = 1,
                    Name = "EFCore",
                    Description = "questions and articles about efcore",
                    Members = new List<Member>
                    {
                        new Member
                        {
                            Id = 1,
                            FirstName = "firstname1",
                            LastName = "lastname1",
                            EmailAddress = "mail@server.com"
                        },new Member
                        {
                            Id = 2,
                            FirstName = "firstname1",
                            LastName = "lastname1",
                            EmailAddress = "mail@server.com"
                        }
                    }
                },
                new Group
                {
                    Id = 2,
                    Name = "WPF .netcore",
                    Description = "questions and articles about wpf",
                    Members = new List<Member>
                    {
                        new Member
                        {
                            Id = 3,
                            FirstName = "firstname1",
                            LastName = "lastname1",
                            EmailAddress = "mail@server.com"
                        }
                    }
                }
            };
        }
    }
}