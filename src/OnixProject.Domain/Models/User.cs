using System;

namespace OnixProject.Domain.Models
{
    public class User
    {
        public User(string name, string mail)
        {
            Name = name;
            Mail = mail;
        }
        protected User() { }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}