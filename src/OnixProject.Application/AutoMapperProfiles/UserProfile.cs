using AutoMapper;
using OnixProject.Application.ViewModels;
using OnixProject.Domain.Models;
using X.PagedList;

namespace OnixProject.Application.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, User>()
                .ConstructUsingServiceLocator()
                .ReverseMap();
            CreateMap<PagedList<UserViewModel>, IPagedList<User>>()
                .ConstructUsingServiceLocator()
                .ReverseMap();
        }
    }
}