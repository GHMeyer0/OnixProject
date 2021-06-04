using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using Microsoft.AspNetCore.JsonPatch;
using OnixProject.Application.ViewModels;
using OnixProject.Domain.Searches;
using System;
using System.Threading.Tasks;

namespace OnixProject.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<PagedList<UserViewModel>> GetAll(UserSearch search);

        Task<UserViewModel> GetById(Guid id);

        Task Update(UserViewModel userView);

        Task PartialUpdate(Guid Id, JsonPatchDocument<UserViewModel> userView);

        Task<UserViewModel> Create(CreateUserRequest userView);

        Task Delete(Guid id);
    }
}