using Domain3.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application3.Interface
{
    public interface ICompanyDbContext
    {
        public DbSet<Company> Company { get; }

        public Task SaveChangesAsync();
    }
}
