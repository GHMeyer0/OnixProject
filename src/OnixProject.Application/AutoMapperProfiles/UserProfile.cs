using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using AutoMapper;
using OnixProject.Application.ViewModels;
using OnixProject.Domain.Commands;
using OnixProject.Domain.Models;

namespace OnixProject.Application.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, UserViewModel>()
                .ConstructUsingServiceLocator()
                .ReverseMap();
            CreateMap<CreateUserCommand, CreateUserRequest>()
                .ConstructUsingServiceLocator()
                .ReverseMap();
            CreateMap<UserViewModel, User>()
                .ConstructUsingServiceLocator()
                .ReverseMap();
            CreateMap<PagedList<UserViewModel>, IPagedList<User>>()
                .ConstructUsingServiceLocator()
                .ReverseMap();
            CreateMap<PagedList<UserViewModel>, PagedList<User>>()
               .ConstructUsingServiceLocator()
               .ReverseMap();
        }
    }
}