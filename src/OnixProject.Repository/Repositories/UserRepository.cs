using AspNetCore.IQueryable.Extensions.Filter;
using Microsoft.EntityFrameworkCore;
using OnixProject.Domain.Models;
using OnixProject.Domain.Repositories;
using OnixProject.Domain.Searches;
using OnixProject.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace OnixProject.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OnixContext context;

        public UserRepository(OnixContext context)
        {
            this.context = context;
        }

        public async Task Delete(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            context.Users.Remove(user);
        }

        public async Task<IPagedList<User>> GetAll(UserSearch search)
        {
            var users = await context.Users.Filter(search).ToPagedListAsync(search.Offset, (int)search.Limit);
            return users;
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            return user;
        }
    }
}