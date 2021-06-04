using System;

namespace OnixProject.Domain.Models
{
    public class User : Entity
    {
        public User(Guid id, string name, string mail)
        {
            Id = id;
            Name = name;
            Mail = mail;
        }
        protected User() { }
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}