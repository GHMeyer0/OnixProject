using OnixProject.Domain.Models;
using OnixProject.Domain.Searches;
using System;
using System.Threading.Tasks;
using X.PagedList;

namespace OnixProject.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid id);
        Task<User> Create(User user);

        Task Delete(Guid id);

        Task<IPagedList<User>> GetAll(UserSearch search);
    }
}