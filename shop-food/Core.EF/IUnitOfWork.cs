using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.EF
{
    public interface IUnitOfWork
    {
        public int SaveChanges();

        public Task<int> SaveChangesAsync();
    }
}