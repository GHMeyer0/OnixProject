﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixProject.Domain.Commands
{
    public class CreateUserCommand : UserCommand
    {
        public CreateUserCommand()
        {
            Id = Guid.NewGuid();
        }
    }
}
