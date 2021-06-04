using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using OnixProject.Application.Services.Interfaces;
using OnixProject.Application.ViewModels;
using OnixProject.Domain.Commands;
using OnixProject.Domain.Repositories;
using OnixProject.Domain.Searches;
using System;
using System.Threading.Tasks;

namespace OnixProject.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public UserService(IUserRepository userRepository, IMapper mapper, IMediator mediator)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<UserViewModel> Create(CreateUserRequest userView)
        {
            var newUser = mapper.Map<CreateUserCommand>(userView);
            await mediator.Send(newUser);
            var userCreated = await userRepository.GetById(newUser.Id);
            return mapper.Map<UserViewModel>(userCreated);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<UserViewModel>> GetAll(UserSearch search)
        {
            var result = await userRepository.GetAll(search);
            return mapper.Map<PagedList<UserViewModel>>(result);
        }

        public Task<UserViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task PartialUpdate(Guid Id, JsonPatchDocument<UserViewModel> document)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserViewModel userView)
        {
            throw new NotImplementedException();
        }
    }
}