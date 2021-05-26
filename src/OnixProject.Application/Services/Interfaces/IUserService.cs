using Microsoft.AspNetCore.JsonPatch;
using OnixProject.Application.ViewModels;
using OnixProject.Domain.Models;
using OnixProject.Domain.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace OnixProject.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IPagedList<UserViewModel>> GetAll(UserSearch search);
        Task<UserViewModel> GetById(Guid id);
        Task Update(UserViewModel userView);
        Task PartialUpdate(Guid Id, JsonPatchDocument<UserViewModel> userView);

        Task<UserViewModel> Create(UserViewModel userView);
        Task Delete(Guid id);
    }
}
