using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Sort;
using Microsoft.EntityFrameworkCore;
using OnixProject.Domain.Models;
using OnixProject.Domain.Repositories;
using OnixProject.Domain.Searches;
using OnixProject.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnixProject.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OnixContext context;
        private readonly DbSet<User> dbSet;
        public UserRepository(OnixContext context)
        {
            this.context = context;
            dbSet = context.Set<User>();
        }
        public async Task Create(User user)
        {
            await dbSet.AddAsync(user);
        }

        public async Task Delete(Guid id)
        {
            var user = await dbSet.FindAsync(id);
            dbSet.Remove(user);
        }

        public async Task<IPagedList<User>> GetAll(UserSearch search)
        {
            var users = await dbSet.Apply(search).ToPagedListAsync((int)search.Page,(int)search.Limit);
            return users;
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await dbSet.FindAsync(id);
            return user;
        }
    }
}