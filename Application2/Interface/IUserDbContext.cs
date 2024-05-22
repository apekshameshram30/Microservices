using Domain2.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Interface
{
    public interface IUserDbContext
    {
        public DbSet<User> UserDetails { get; }

        Task SaveChangesAsync();
    }
}
