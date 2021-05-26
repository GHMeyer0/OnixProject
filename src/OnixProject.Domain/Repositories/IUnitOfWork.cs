using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixProject.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
