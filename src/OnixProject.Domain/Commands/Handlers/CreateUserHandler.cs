using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using OnixProject.Domain.Commands;
using OnixProject.Domain.Models;
using OnixProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnixProject.Domain.Handlers
{
    public class CreateUserHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }


        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Id, request.Name, request.Email);
            await userRepository.Create(user);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
