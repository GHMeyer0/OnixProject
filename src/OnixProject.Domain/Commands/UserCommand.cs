using MediatR;
using System;

namespace OnixProject.Domain.Commands
{
    public abstract class UserCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }
    }
}