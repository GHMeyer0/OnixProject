using AutoMapper;
using OnixProject.Application.Services.Interfaces;
using OnixProject.Application.ViewModels;
using OnixProject.Domain.Models;
using OnixProject.Domain.Repositories;
using OnixProject.Domain.Searches;
using System;
using System.Threading.Tasks;
using X.PagedList;

namespace OnixProject.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public Task<UserViewModel> Create(UserViewModel userView)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IPagedList<UserViewModel>> GetAll(UserSearch search)
        {
            var result = await userRepository.GetAll(search);
            return mapper.Map<IPagedList<UserViewModel>>(result);
        }

        public Task<UserViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> Update(UserViewModel userView)
        {
            throw new NotImplementedException();
        }
    }
}